using System.Windows;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.DataStorage;
using hogwartsBingus.Session;

namespace hogwartsBingus.UI_Classes
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private void OnAppStartup(object sender, StartupEventArgs e)
        {
            WindowManager.AppStartup();

            UserManager.addUser(new Student(new LoginData("nima", "123")));
            UserManager.addUser(new Professor(new LoginData("ali", "1234")));
        }
    }
}