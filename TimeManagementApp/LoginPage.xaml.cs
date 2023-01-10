using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Data.SqlClient;
using System;
using TimeManagementClassLibrary;
using System.Text;

namespace TimeManagementApp
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtStudentNum.Text) && !string.IsNullOrWhiteSpace(txtPassword.Password)) {
                string query = $"SELECT * FROM Student WHERE StudentNum = '{txtStudentNum.Text}';";
                //Use connection string stored in project settings
                using (SqlConnection connection = new(Properties.Settings.Default.DBCS))
                {
                    using SqlCommand command = new(query, connection);
                    try
                    {
                        connection.Open();
                        using SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            string stNum = "" + reader["StudentNum"];
                            string name = "" + reader["Name"];
                            string pass = "" + reader["Password"];
                            if (pass.Equals(Student.Hash(txtPassword.Password)))
                            {
                                reader.Close();
                                MainWindow mainWindow = new(new Student(stNum, name, pass, false));
                                mainWindow.Show();
                                Window.GetWindow(this).Close();
                                return;
                            }
                        }
                        MessageBox.Show("Username or Password Incorrect", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            MessageBox.Show("Enter a Username and Password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            //Navigation service adapted from
            //https://stackoverflow.com/questions/26968843/how-to-get-parent-frame-from-page-level
            //User answered:
            //https://stackoverflow.com/users/1679602/king-king
            //Accessed 11 November 2022
            RegisterPage register = new();
            NavigationService.Navigate(register);
        }
    }
}
