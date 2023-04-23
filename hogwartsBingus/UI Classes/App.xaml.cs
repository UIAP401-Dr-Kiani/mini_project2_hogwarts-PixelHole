using System.Windows;
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
        }
    }
}