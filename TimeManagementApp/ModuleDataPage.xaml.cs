using System;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
//using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using TimeManagementClassLibrary;

namespace TimeManagementApp
{
    /// <summary>
    /// Interaction logic for ModuleDataPage.xaml
    /// </summary>
    public partial class ModuleDataPage : Page
    {
        public static Module CurrentModule { get; set; } = null!;

        public ModuleDataPage()
        {
            InitializeComponent();
            //No module was selected in the semester data page
            if (CurrentModule.Code.Equals("dummy"))
            {
                //Change header to name of module
                foreach (var w in Application.Current.Windows)
                {
                    if (w.GetType().Name == "InfoWindow")
                    {
                        InfoWindow wind = (InfoWindow)w;
                        wind.lblHeader.Content = "All Modules";
                    }
                }
                //Change view of page to best display data, adapted from
                //https://social.msdn.microsoft.com/Forums/vstudio/en-US/1747bcdf-5f8a-4210-895a-24fdf9568670/set-grid-row-height-in-c?forum=wpf
                //Accessed 19 September 2022
                stkInput.Visibility = Visibility.Hidden;
                lblHoursWorked.Visibility = Visibility.Hidden;
                DataRow.Height = new GridLength(5, GridUnitType.Star);
                brdData.Height = 250;
                PopulateTextBlock(false); 
            }
            else
            {
                //Change header to name of module
                foreach (var w in Application.Current.Windows)
                {
                    if (w.GetType().Name == "InfoWindow")
                    {
                        InfoWindow wind = (InfoWindow)w;
                        wind.lblHeader.Content = CurrentModule.Name;
                    }
                }
                //Change view of page to best display data
                stkInput.Visibility = Visibility.Visible;
                lblHoursWorked.Visibility = Visibility.Visible;
                DataRow.Height = new GridLength(3, GridUnitType.Star);
                brdData.Height = 225;
                //Set range for date picker
                dtpHoursWorked.DisplayDateStart = InfoWindow.CurrentSemester.StartDate;
                dtpHoursWorked.DisplayDateEnd = InfoWindow.CurrentSemester.EndDate;
                PopulateTextBlock(true);
            }
        }

        private void PopulateTextBlock(bool single)
        {
            //Make sure textblock is clean
            txbModuleData.Text = "";
            if (single)
            {
                //Populate Textblock with selected module
                var result = from module in MainWindow.Modules
                             where module.ModuleID.Equals(CurrentModule.ModuleID)
                             select module;
                foreach (var mod in result)
                {
                    txbModuleData.Text += mod.ToString();
                }
            }
            else
            {
                //Populate Textblock with all modules
                var result = from module in MainWindow.Modules
                             select module;
                foreach (var mod in result)
                {
                    txbModuleData.Text += mod.ToString();
                }
            }
        }

        private void btnViewSemester_Click(object sender, RoutedEventArgs e)
        {
            //Clear current studyhours
            MainWindow.StudyHours.Clear();

            //Return to Semester Data Page
            foreach (var w in Application.Current.Windows)
            {
                if (w.GetType().Name == "InfoWindow")
                {
                    InfoWindow wind = (InfoWindow)w;
                    wind.DataFrame.Content = new SemesterDataPage();
                }
            }
        }

        private void chkToday_Checked(object sender, RoutedEventArgs e)
        {
            if (DateTime.Now < InfoWindow.CurrentSemester.StartDate || DateTime.Now > InfoWindow.CurrentSemester.EndDate)
            {
                MessageBox.Show("Today's date isn't part of the current semester.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                chkToday.IsChecked = false;
            }
            else
            {
                dtpHoursWorked.SelectedDate = DateTime.Now;
                dtpHoursWorked.IsEnabled = false;
            }
        }

        private void chkToday_Unchecked(object sender, RoutedEventArgs e)
        {
            dtpHoursWorked.IsEnabled = true;
            dtpHoursWorked.SelectedDate = null;
        }

        private new void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //Textbox input check from:
            //https://abundantcode.com/how-to-allow-only-numeric-input-in-a-textbox-in-wpf/
            //Accessed 14 September 2022
            Regex regex = new("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            bool success = true;
            int hWorked = 0;
            txtHoursWorked.BorderBrush = (Brush)MainWindow.Bc.ConvertFrom("#FFABADB3");
            //Check if hours are valid, then update remaining weekly self study hours
            if (string.IsNullOrWhiteSpace(txtHoursWorked.Text))
            {
                txtHoursWorked.BorderBrush = (Brush)MainWindow.Bc.ConvertFrom("#FF0000");
                success = false;
            }
            else if (!int.TryParse(txtHoursWorked.Text, out hWorked))
            {
                txtHoursWorked.BorderBrush = (Brush)MainWindow.Bc.ConvertFrom("#FF0000");
                success = false;
            }
            else if (hWorked > 24)
            {
                MessageBox.Show("Hours worked cannot be more than 24.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                success = false;
            }

            if (success)
            {
                //Get week of module and subtract the hours worked from it
                Module module = (from m in MainWindow.Modules where m.ModuleID.Equals(CurrentModule.ModuleID) select m).First();
                StudyHours st = (from s in module.st where dtpHoursWorked.SelectedDate >= s.Date && dtpHoursWorked.SelectedDate < (s.Date + new TimeSpan(7, 0, 0, 0)) select s).First();
                int index = module.st.IndexOf(st);
                st.RemainingStudyHours -= hWorked;
                //Remaining hours cannot be less than 0
                if (st.RemainingStudyHours < 0)
                {
                    st.RemainingStudyHours = 0;
                }
                module.st[index] = st;

                //Send updated StudyHours to database on seperate thread
                //Thread with parameter adapted from
                //https://stackoverflow.com/questions/14854878/creating-new-thread-with-method-with-parameter
                //User answered
                //https://stackoverflow.com/users/834908/igoy
                //Accessed 14 November 2022
                Thread t = new (() => UpdateDBStudyHours(st));
                t.Start();
            }
        }

        private void UpdateDBStudyHours(StudyHours st)
        {
            string query = $"UPDATE StudyHours SET RemainingStudyHours = {st.RemainingStudyHours} WHERE StudyHoursID = {st.StudyHoursID};";
            //Use connection string stored in project settings
            using (SqlConnection connection = new(Properties.Settings.Default.DBCS))
            {
                using SqlCommand command = new(query, connection);
                try
                {
                    connection.Open();
                    int num = command.ExecuteNonQuery();
                    //MessageBox.Show("Successfully updated study hours");
                    MessageBox.Show($"Successfully updated study hours for week {st.Week}.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            Dispatcher.Invoke(() =>
            {
                PopulateTextBlock(true);
            });
        }
    }
}
