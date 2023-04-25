using System.Security.RightsManagement;
using System.Windows;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.UI_Classes;

namespace hogwartsBingus.Session
{
    public static class WindowManager
    {
        private static Window CurrentWindow;

        public static void AppStartup()
        {
            LaunchLoginPage();
        }
        public static void LaunchLoginPage()
        {
            CloseCurrentWindow();
            CurrentWindow = new LoginWindow();
            ShowCurrentWindow();
        }
        public static void LaunchLandingPageOfType(AuthorizationType type)
        {
            CloseCurrentWindow();
            switch (type)
            {
                case AuthorizationType.Student:
                    CurrentWindow = new StudentLandingPage();
                    break;
                
                case AuthorizationType.Professor:
                    CurrentWindow = new ProfessorLandingPage();
                    break;
                
                case AuthorizationType.Dumbledore:
                    CurrentWindow = new DumbledoreLandingPage();
                    break;
            }
            ShowCurrentWindow();
        }

        private static void CloseCurrentWindow()
        {
            if (CurrentWindow == null)
            {
                return;
            }
            
            CurrentWindow.Close();
        }

        private static void ShowCurrentWindow()
        {
            if (CurrentWindow == null)
            {
                return;
            }
            
            CurrentWindow.Show();
        }
    }
}