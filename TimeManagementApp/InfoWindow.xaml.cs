using System;
using System.Data.SqlClient;
using System.Threading;
using System.Windows;
using TimeManagementClassLibrary;

namespace TimeManagementApp
{
    /// <summary>
    /// Interaction logic for InfoWindow.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {
        private static Semester currentSemester = Module.tempSemester;

        public static Semester CurrentSemester { get => currentSemester; set => currentSemester = value; }

        public InfoWindow()
        {
            InitializeComponent();
            //Header set by pages
            //lblHeader.Content = CurrentSemester.SemesterID + " AHH kms";

            //Date time format from
            //https://www.c-sharpcorner.com/blogs/date-and-time-format-in-c-sharp-programming1
            //Suresh M
            //Accessed 18 September 2022
            lblDate.Content = DateTime.Now.ToString("dd MMMM yyyy");
            SemesterDataPage semesterDataPage = new();
            DataFrame.Content = semesterDataPage;

            //Get data from DB without freezing UI
            Thread dbModules = new(GetDBModules);
            //Thread dbStudyHours = new(GetDBStudyHours);
            dbModules.Start();
            //dbStudyHours.Start();
        }

        public void GetDBModules()
        {
            string query = $"SELECT * FROM Module WHERE SemesterID = '{CurrentSemester.SemesterID}';";
            //Use connection string stored in project settings
            using (SqlConnection connection = new(Properties.Settings.Default.DBCS))
            {
                using SqlCommand command = new(query, connection);
                try
                {
                    connection.Open();
                    using SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["ModuleID"]);
                        string code = "" + reader["Code"];
                        string name = "" + reader["Name"];
                        int numCredits = Convert.ToInt32(reader["NumCredits"]);
                        int classHoursPerWeek = Convert.ToInt32(reader["ClassHoursPerWeek"]);
                        Module m = new (id, code, name, numCredits, classHoursPerWeek, CurrentSemester, false);
                        //Add studyHours to module
                        GetDBStudyHours(m);
                        MainWindow.Modules.Add(m);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            this.Dispatcher.Invoke(() =>
            {
                SemesterDataPage semesterDataPage = new();
                DataFrame.Content = semesterDataPage;
            });
        }

        private void GetDBStudyHours(Module m)
        {
            string query = $"SELECT * FROM StudyHours WHERE ModuleID = '{m.ModuleID}';";
            //Use connection string stored in project settings
            using (SqlConnection connection = new(Properties.Settings.Default.DBCS))
            {
                using SqlCommand command = new(query, connection);
                try
                {
                    connection.Open();
                    using SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["StudyHoursID"]);
                        int week = Convert.ToInt32(reader["Week"]);
                        double remainingStudyHours = Convert.ToDouble(reader["RemainingStudyHours"]);
                        DateTime date = DateTime.Parse("" + reader["Date"]);
                        StudyHours st = new(id, week, remainingStudyHours, date, m.ModuleID);
                        MainWindow.StudyHours.Add(st);
                        m.st.Add(st);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            //this.Dispatcher.Invoke(() =>
            //{
            //    SemesterDataPage semesterDataPage = new();
            //    DataFrame.Content = semesterDataPage;
            //});
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            //Clear current modules
            MainWindow.Modules.Clear();
            //Go back to main window
            MainWindow mainWindow = new(MainWindow.CurrentStudent);
            mainWindow.Show();
            Close();
        }

        private void btnAddModule_Click(object sender, RoutedEventArgs e)
        {
            ModuleWindow moduleInput = new();
            moduleInput.Show();
            ModuleWindow.FromNewSemester = false;
            this.IsEnabled = false;
        }
    }
}
