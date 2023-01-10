using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using TimeManagementClassLibrary;

namespace TimeManagementApp
{
    /// <summary>
    /// Interaction logic for SemesterWindow.xaml
    /// </summary>
    public partial class SemesterWindow : Window
    {
        private static bool success;
        //Temporarily holds modules created while creating a semester
        private static List<Module> tempModules = new();

        public static List<Module> TempModules { get => tempModules; set => tempModules = value; }

        public SemesterWindow()
        {
            InitializeComponent();
        }

        public void UpdateModuleList()
        {
            //Refresh list of modules
            lstModules.Items.Clear();
            foreach (var module in TempModules)
            {
                lstModules.Items.Add(module.Code);
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string name;
            int weeks = 0;
            DateTime start = DateTime.MinValue;
            //Set borders to default
            txtSemesterName.BorderBrush = (Brush)MainWindow.Bc.ConvertFrom("#FFABADB3");
            txtNumWeeks.BorderBrush = (Brush)MainWindow.Bc.ConvertFrom("#FFABADB3");
            dtpStartDate.BorderBrush = (Brush)MainWindow.Bc.ConvertFrom("#FFABADB3");
            success = true;
            //Semester Name
            if (string.IsNullOrWhiteSpace(txtSemesterName.Text))
            {
                txtSemesterName.BorderBrush = (Brush)MainWindow.Bc.ConvertFrom("#FF0000");
                success = false;
            }
            foreach (var semester in MainWindow.Semesters)
            {
                if (semester.SemesterName.Equals(txtSemesterName.Text))
                {
                    MessageBox.Show(wndNewSemester, "Semester name already exists.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtSemesterName.BorderBrush = (Brush)MainWindow.Bc.ConvertFrom("#FF0000");
                    success = false;
                }
            }
            name = txtSemesterName.Text;
            //Number of Weeks
            if (string.IsNullOrWhiteSpace(txtNumWeeks.Text))
            {
                txtNumWeeks.BorderBrush = (Brush)MainWindow.Bc.ConvertFrom("#FF0000");
                success = false;
            }
            else if (!int.TryParse(txtNumWeeks.Text, out weeks))
            {
                txtNumWeeks.BorderBrush = (Brush)MainWindow.Bc.ConvertFrom("#FF0000");
                success = false;
            }
            //Start Date
            if (string.IsNullOrWhiteSpace(dtpStartDate.Text))
            {
                dtpStartDate.BorderBrush = (Brush)MainWindow.Bc.ConvertFrom("#FF0000");
                success = false;
            }
            else if (!DateTime.TryParse(dtpStartDate.Text, out start))
            {
                dtpStartDate.BorderBrush = (Brush)MainWindow.Bc.ConvertFrom("#FF0000");
                success = false;
            }
            //Success
            if (success)
            {
                Semester s = new(name, weeks, start, MainWindow.CurrentStudent.StudentNum);
                foreach (var module in TempModules)
                {
                    module.SetSemester(s);
                }
                s.AddModule(TempModules);
                MainWindow.Semesters.Add(s);
                TempModules.Clear();
                Close();
            }
        }

        private new void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //Textbox input check from:
            //https://abundantcode.com/how-to-allow-only-numeric-input-in-a-textbox-in-wpf/
            //Accessed 14 September 2022
            Regex regex = new("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!success)
            {
                MessageBoxResult result = MessageBox.Show("Do you want to exit without saving?.", "Result", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.No)
                {
                    //Stay on window without closing if no is clicked
                    e.Cancel = true;
                }
                else
                {
                    //Re enable controls of main window
                    foreach (var w in Application.Current.Windows)
                    {
                        if (w.GetType().Name == "MainWindow")
                        {
                            MainWindow wind = (MainWindow)w;
                            wind.IsEnabled = true;
                            wind.UpdateSemesterList();
                        }
                    }
                }
            }
            else
            {
                //Re enable controls of main window
                foreach (var w in Application.Current.Windows)
                {
                    if (w.GetType().Name == "MainWindow")
                    {
                        MainWindow wind = (MainWindow)w;
                        wind.IsEnabled = true;
                        wind.UpdateSemesterList();
                    }
                }
            }
            //Reset location variables
            success = false;
        }

        private void btnPlusModule_Click(object sender, RoutedEventArgs e)
        {
            ModuleWindow moduleInput = new();
            moduleInput.Show();
            ModuleWindow.FromNewSemester = true;
            this.IsEnabled = false;
        }

        private void btnMinusModule_Click(object sender, RoutedEventArgs e)
        {
            if (lstModules.SelectedIndex == -1)
            {
                MessageBox.Show(wndNewSemester, "No Module Selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show(wndNewSemester, $"Are you sure you want to delete {lstModules.SelectedItem}?", "Delete Module", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    //Remove selected module from collection, adapted from
                    //https://stackoverflow.com/questions/3279145/remove-item-from-list-based-on-condition
                    //User answered
                    //https://stackoverflow.com/users/44389/noldorin
                    //18 September 2022
                    TempModules.RemoveAll(m => m.Code.Equals(lstModules.SelectedItem));
                    UpdateModuleList();
                }
            }
        }
    }
}
