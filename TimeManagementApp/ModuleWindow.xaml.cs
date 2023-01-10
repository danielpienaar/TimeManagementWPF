using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using TimeManagementClassLibrary;

namespace TimeManagementApp
{
    /// <summary>
    /// Interaction logic for ModuleWindow.xaml
    /// </summary>
    public partial class ModuleWindow : Window
    {
        private static bool success;
        private static bool fromNewSemester;

        public static bool FromNewSemester { get => fromNewSemester; set => fromNewSemester = value; }

        public ModuleWindow()
        {
            InitializeComponent();
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
                    //Re enable controls
                    if (FromNewSemester)
                    {
                        foreach (var w in Application.Current.Windows)
                        {
                            if (w.GetType().Name == "SemesterWindow")
                            {
                                SemesterWindow wind = (SemesterWindow)w;
                                wind.IsEnabled = true;
                                //Update module list
                                wind.UpdateModuleList();
                            }
                        }
                    }
                    else
                    {
                        foreach (var w in Application.Current.Windows)
                        {
                            if (w.GetType().Name == "InfoWindow")
                            {
                                InfoWindow wind = (InfoWindow)w;
                                wind.IsEnabled = true;
                                //Update module list
                                wind.DataFrame.Content = new SemesterDataPage();
                            }
                        }
                    }
                }
            }
            else
            {
                //Re enable controls
                if (FromNewSemester)
                {
                    foreach (var w in Application.Current.Windows)
                    {
                        if (w.GetType().Name == "SemesterWindow")
                        {
                            SemesterWindow wind = (SemesterWindow)w;
                            wind.IsEnabled = true;
                            //Update module list
                            wind.UpdateModuleList();
                        }
                    }
                }
                else
                {
                    foreach (var w in Application.Current.Windows)
                    {
                        if (w.GetType().Name == "InfoWindow")
                        {
                            InfoWindow wind = (InfoWindow)w;
                            wind.IsEnabled = true;
                            //Update module list
                            wind.DataFrame.Content = new SemesterDataPage();
                        }
                    }
                }
            }
            //Reset location variables
            FromNewSemester = false;
            success = false;
        }

        private new void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string code, name;
            int credits = 0, classHours = 0;
            //Set borders to default
            txtModuleCode.BorderBrush = (Brush)MainWindow.Bc.ConvertFrom("#FFABADB3");
            txtModuleName.BorderBrush = (Brush)MainWindow.Bc.ConvertFrom("#FFABADB3");
            txtNumCredits.BorderBrush = (Brush)MainWindow.Bc.ConvertFrom("#FFABADB3");
            txtClassHours.BorderBrush = (Brush)MainWindow.Bc.ConvertFrom("#FFABADB3");
            success = true;
            //Module Code
            if (string.IsNullOrWhiteSpace(txtModuleCode.Text))
            {
                txtModuleCode.BorderBrush = (Brush)MainWindow.Bc.ConvertFrom("#FF0000");
                success = false;
            }
            if (FromNewSemester)
            {
                foreach (var module in SemesterWindow.TempModules)
                {
                    //Compare strings ignoring case, adapted from
                    //https://stackoverflow.com/questions/6371150/comparing-two-strings-ignoring-case-in-c-sharp
                    //User answered
                    //https://stackoverflow.com/users/784449/sven
                    //Accessed 18 September 2022
                    if (string.Equals(module.Code, txtModuleCode.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show(wndNewModule, "Module Code already exists in the Semester.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtModuleCode.BorderBrush = (Brush)MainWindow.Bc.ConvertFrom("#FF0000");
                        success = false;
                    }
                }
            }
            else
            {
                foreach (var module in InfoWindow.CurrentSemester.modules)
                {
                    //Compare strings ignoring case, adapted from
                    //https://stackoverflow.com/questions/6371150/comparing-two-strings-ignoring-case-in-c-sharp
                    //User answered
                    //https://stackoverflow.com/users/784449/sven
                    //Accessed 18 September 2022
                    if (string.Equals(module.Code, txtModuleCode.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show(wndNewModule, "Module Code already exists in the Semester.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtModuleCode.BorderBrush = (Brush)MainWindow.Bc.ConvertFrom("#FF0000");
                        success = false;
                    }
                }
            }
            code = txtModuleCode.Text;
            //Module Name
            if (string.IsNullOrWhiteSpace(txtModuleName.Text))
            {
                txtModuleName.BorderBrush = (Brush)MainWindow.Bc.ConvertFrom("#FF0000");
                success = false;
            }
            name = txtModuleName.Text;
            //Module Credits
            if (string.IsNullOrWhiteSpace(txtNumCredits.Text))
            {
                txtNumCredits.BorderBrush = (Brush)MainWindow.Bc.ConvertFrom("#FF0000");
                success = false;
            }
            else if(!int.TryParse(txtNumCredits.Text, out credits))
            {
                txtNumCredits.BorderBrush = (Brush)MainWindow.Bc.ConvertFrom("#FF0000");
                success = false;
            }
            //Class Hours
            if (string.IsNullOrWhiteSpace(txtClassHours.Text))
            {
                txtClassHours.BorderBrush = (Brush)MainWindow.Bc.ConvertFrom("#FF0000");
                success = false;
            }
            else if (!int.TryParse(txtClassHours.Text, out classHours))
            {
                txtClassHours.BorderBrush = (Brush)MainWindow.Bc.ConvertFrom("#FF0000");
                success = false;
            }
            //Success
            if (success)
            {
                if (FromNewSemester)
                {
                    Module m = new(code, name, credits, classHours);
                    SemesterWindow.TempModules.Add(m);
                }
                else
                {
                    Module m = new(code, name, credits, classHours, InfoWindow.CurrentSemester);
                    InfoWindow.CurrentSemester.modules.Add(m);
                    MainWindow.Modules.Add(m);
                    //Update datagrid
                    Dispatcher.Invoke(() =>
                    {
                        foreach (var w in Application.Current.Windows)
                        {
                            if (w.GetType().Name == "InfoWindow")
                            {
                                InfoWindow wind = (InfoWindow)w;
                                wind.DataFrame.Content = new SemesterDataPage();
                            }
                        }
                    });
                }
                Close();
            }
        }
    }
}
