using System.Data.SqlClient;
using System;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using TimeManagementClassLibrary;

namespace TimeManagementApp
{
    /// <summary>
    /// Interaction logic for SemesterDataPage.xaml
    /// </summary>
    public partial class SemesterDataPage : Page
    {
        public SemesterDataPage()
        {
            InitializeComponent();
            //Set items source and update header to be name of semester
            foreach (var w in Application.Current.Windows)
            {
                if (w.GetType().Name == "InfoWindow")
                {
                    InfoWindow wind = (InfoWindow)w;
                    dtgModules.ItemsSource = MainWindow.Modules;
                    wind.lblHeader.Content = InfoWindow.CurrentSemester.SemesterName;
                }
            }
        }

        private void btnViewModule_Click(object sender, RoutedEventArgs e)
        {
            if (dtgModules.SelectedIndex != -1 && dtgModules.SelectedItems[0] is Module mod)
            {
                //View specific module to edit
                foreach (var w in Application.Current.Windows)
                {
                    if (w.GetType().Name == "InfoWindow")
                    {
                        InfoWindow wind = (InfoWindow)w;
                        ModuleDataPage.CurrentModule = (from m in MainWindow.Modules where m.ModuleID.Equals(mod.ModuleID) select m).First();
                        wind.DataFrame.Content = new ModuleDataPage();
                    }
                }
            }
            else
            {
                //Show all modules if none selected
                foreach (var w in Application.Current.Windows)
                {
                    if (w.GetType().Name == "InfoWindow")
                    {
                        InfoWindow wind = (InfoWindow)w;
                        //Pass dummy module to show all module data
                        ModuleDataPage.CurrentModule = new Module("dummy", "dummy", 0, 0);
                        wind.DataFrame.Content = new ModuleDataPage();
                    }
                }
            }
        }

        private void btnDeleteModule_Click(object sender, RoutedEventArgs e)
        {
            if (dtgModules.SelectedIndex != -1 && dtgModules.SelectedItems[0] is Module mod)
            {
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete {mod.Name}?", "Delete Module", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    //Remove selected module from collections, adapted from
                    //https://stackoverflow.com/questions/3279145/remove-item-from-list-based-on-condition
                    //User answered
                    //https://stackoverflow.com/users/44389/noldorin
                    //18 September 2022
                    InfoWindow.CurrentSemester.modules.RemoveAll(m => m.ModuleID.Equals(mod.ModuleID));
                    MainWindow.Modules.RemoveAll(m => m.ModuleID.Equals(mod.ModuleID));

                    //Remove module from db without freezing UI
                    Thread t = new(() => DeleteDBModule(mod.ModuleID));
                    t.Start();
                }
            }
            else
            {
                MessageBox.Show("No Module Selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteDBModule(int modID)
        {
            string query = $"DELETE FROM Module WHERE ModuleID = {modID};";
            //Use connection string stored in project settings
            using (SqlConnection connection = new(Properties.Settings.Default.DBCS))
            {
                using SqlCommand command = new(query, connection);
                try
                {
                    connection.Open();
                    int num = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Delete Module: " + ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
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
    }
}
