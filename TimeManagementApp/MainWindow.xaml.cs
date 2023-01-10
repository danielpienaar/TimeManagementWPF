using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using TimeManagementClassLibrary;

namespace TimeManagementApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Logged in student data
        public static Student CurrentStudent { get; set; } = null!;
        public static List<Semester> Semesters { get; set; } = new List<Semester>();
        public static List<Module> Modules { get; set; } = new List<Module>();
        public static List<StudyHours> StudyHours { get; set; } = new List<StudyHours>();

        //BrushConverter
        public static BrushConverter Bc { get; set; } = null!;

        public MainWindow(Student s)
        {
            InitializeComponent();
            CurrentStudent = s;
            lblWelcome.Content = "Hi " + s.Name;

            //Get data from DB without freezing UI
            Thread dbThread = new(() =>
            {
                GetDBSemesters();
            });
            dbThread.Start();

            Bc = new BrushConverter();
        }

        public void GetDBSemesters()
        {
            Semesters.Clear();
            string query = $"SELECT * FROM Semester WHERE StudentNum = '{CurrentStudent.StudentNum}';";
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
                        string semesterName = "" + reader["SemesterName"];
                        int numWeeks = (int)reader["NumWeeks"];
                        DateTime startDate = DateTime.Parse("" + reader["StartDate"]);
                        string studentNum = "" + reader["StudentNum"];
                        Semesters.Add(new(semesterName, numWeeks, startDate, studentNum, false));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            //Update UI using UI thread
            //https://stackoverflow.com/questions/9732709/the-calling-thread-cannot-access-this-object-because-a-different-thread-owns-it
            //User answered
            //https://stackoverflow.com/users/630654/candide
            //Accessed 13 November 2022
            this.Dispatcher.Invoke(() =>
            {
                UpdateSemesterList();
            });
        }

        public void UpdateSemesterList()
        {
            //Refresh list of Semesters
            cmbSemesters.Items.Clear();
            foreach (var semester in Semesters)
            {
                cmbSemesters.Items.Add(semester.SemesterID);
            }
        }

        private void btnNewSemester_Click(object sender, RoutedEventArgs e)
        {
            SemesterWindow semesterInput = new();
            semesterInput.Show();
            this.IsEnabled = false;
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            if (cmbSemesters.SelectedIndex != -1)
            {
                string query = $"SELECT * FROM Semester WHERE SemesterID = '{cmbSemesters.SelectedItem}';";
                //Use connection string stored in project settings
                using (SqlConnection connection = new(Properties.Settings.Default.DBCS))
                {
                    using SqlCommand command = new(query, connection);
                    try
                    {
                        connection.Open();
                        using SqlDataReader reader = command.ExecuteReader();
                        reader.Read();
                        string semesterName = "" + reader["SemesterName"];
                        int numWeeks = (int)reader["NumWeeks"];
                        DateTime startDate = DateTime.Parse("" + reader["StartDate"]);
                        string studentNum = "" + reader["StudentNum"];
                        Semester s = new(semesterName, numWeeks, startDate, studentNum, false);
                        InfoWindow.CurrentSemester = s;
                        InfoWindow info = new();
                        info.Show();
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }

                //Get the selected semester using linq and pass it to the new window
                //Semester semester = (from s in Semesters where s.SemesterName.Equals(cmbSemesters.SelectedItem) select s).First();
                //InfoWindow info = new(semester);
                //info.Show();
                //Close();
            }
            else
            {
                MessageBox.Show(wndMainWindow, "Select a semester, or create a new one.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDeleteSemester_Click(object sender, RoutedEventArgs e)
        {
            if (cmbSemesters.SelectedIndex != -1)
            {
                MessageBoxResult confirm = MessageBox.Show(wndMainWindow, $"Are you sure you want to delete {cmbSemesters.SelectedItem}?", "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (confirm == MessageBoxResult.Yes)
                {
                    //Semesters.RemoveAll(s => s.SemesterID.Equals(cmbSemesters.SelectedItem));
                    //UpdateSemesterList();

                    //Delete semester from DB
                    string query = $"DELETE FROM Semester WHERE SemesterID = '{cmbSemesters.SelectedItem}';";
                    //Use connection string stored in project settings
                    using (SqlConnection connection = new(Properties.Settings.Default.DBCS))
                    {
                        using SqlCommand command = new(query, connection);
                        try
                        {
                            connection.Open();
                            int num = command.ExecuteNonQuery();
                            MessageBox.Show("Successfully deleted semesters: " + num);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Delete Semester: " + ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }
                    //Get data from DB without freezing UI
                    Thread dbThread = new(() =>
                    {
                        GetDBSemesters();
                    });
                    dbThread.Start();
                }
            }
            else
            {
                MessageBox.Show(wndMainWindow, "Select a semester, or create a new one.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            //Clear data
            CurrentStudent = new("", "", "", false);
            Semesters.Clear();
            Modules.Clear();
            StudyHours.Clear();

            //Return to login
            LoginWindow login = new();
            login.Show();
            Close();
        }
    }
}
