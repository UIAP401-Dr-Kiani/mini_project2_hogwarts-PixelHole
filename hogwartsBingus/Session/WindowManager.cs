using System.Security.RightsManagement;
using System.Windows;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.UI_Classes;
using System.Collections.Generic;

namespace hogwartsBingus.Session
{
    public static class WindowManager
    {
        private static readonly List<Window> windows = new List<Window>();

        public static void AppStartup()
        {
            LaunchLoginPage();
        }
        public static void LaunchLoginPage()
        {
            
        }
        public static void LaunchLandingPageOfType(AuthorizationType type)
        {
            switch (type)
            {
                case AuthorizationType.Student:
                    break;
                
                case AuthorizationType.Professor:
                    break;
                
                case AuthorizationType.Dumbledore:
                    break;
            }
        }
    }
}