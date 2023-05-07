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
            catch(LoginNotFoundException loginException)
            {
                ErrorLabel.Content = "Login Credentials Not Found";
            }
        }
    }
}