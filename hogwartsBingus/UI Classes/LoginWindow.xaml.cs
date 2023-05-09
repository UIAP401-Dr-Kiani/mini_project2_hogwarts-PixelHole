using System;
using System.Windows;
using hogwartsBingus.DataStorage;
using hogwartsBingus.Execptions;
using hogwartsBingus.Session;
using hogwartsBingus.University.DormitoryData;

namespace hogwartsBingus.UI_Classes
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SessionManager.Login(UsernameField.Text, PasswordField.Password);
            }
            catch (LoginNotFoundException)
            {
                ErrorLabel.Content = "Login Credentials Not Found";
            }
            catch (AuthorizedPersonTypeNotFoundException)
            {
                ErrorLabel.Content = "Login found, but no Auth-type assigned to your account";
            }
        }

        private void LoginWindow_OnClosed(object sender, EventArgs e)
        {
            WindowManager.UnTrackWindow(this);
        }
    }
}