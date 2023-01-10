using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TimeManagementClassLibrary;

namespace TimeManagementApp
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtStudentNum.Text) && !string.IsNullOrWhiteSpace(txtName.Text) && !string.IsNullOrWhiteSpace(txtPassword.Password))
            {
                Student s = new(txtStudentNum.Text, txtName.Text, txtPassword.Password);
                if (!s.StudentNum.Equals("Fail"))
                {
                    LoginPage login = new();
                    NavigationService.Navigate(login);
                    return;
                }
                return;
            }
            MessageBox.Show("Please fill in all details", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            //Navigation service adapted from
            //https://stackoverflow.com/questions/26968843/how-to-get-parent-frame-from-page-level
            //User answered:
            //https://stackoverflow.com/users/1679602/king-king
            //Accessed 11 November 2022
            LoginPage login = new();
            NavigationService.Navigate(login);
        }
    }
}
