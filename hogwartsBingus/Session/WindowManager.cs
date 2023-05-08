using System.Security.RightsManagement;
using System.Windows;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.UI_Classes;
using System.Collections.Generic;
using System.Linq;
using hogwartsBingus.Execptions;
using hogwartsBingus.UI_Classes.Profile_UI;

namespace hogwartsBingus.Session
{
    public static class WindowManager
    {
        private static readonly List<Window> TrackedWindows = new List<Window>();
        
        private static readonly string ProfileInfoName = "ProfileInfo", EditLoginName = "EditLogin";
        public static void AppStartup()
        {
            LaunchLoginPage();
        }
        public static void LaunchLoginPage()
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            
            CloseAllWindows();
            TrackWindow(loginWindow);
        }
        public static void LaunchLandingPageOfType(AuthorizationType type)
        {
            switch (type)
            {
                case AuthorizationType.Student:
                    StudentLandingPage studentLandingPage = new StudentLandingPage();
                    OpenAndTrackWindow(studentLandingPage, true);
                    break;
                
                case AuthorizationType.Professor:
                    ProfessorLandingPage professorLandingPage = new ProfessorLandingPage();
                    OpenAndTrackWindow(professorLandingPage, true);
                    break;
                
                case AuthorizationType.Dumbledore:
                    DumbledoreLandingPage dumbledoreLandingPage = new DumbledoreLandingPage();
                    OpenAndTrackWindow(dumbledoreLandingPage, true);
                    break;
                default:
                    throw new AuthorizedPersonTypeNotFoundException("the Authorized person's type not recognised");
            }
        }

        public static void OpenProfileInfoWindow()
        {
            if (FindWindowWithName(ProfileInfoName) != null) return;

            ProfileInfoWindow profileInfoWindow = new ProfileInfoWindow();
            profileInfoWindow.Name = ProfileInfoName;
            
            OpenAndTrackWindow(profileInfoWindow, false);
        }

        public static void OpenEditLoginWindow()
        {
            if (FindWindowWithName(EditLoginName) != null) return;

            EditLoginWindow editLoginWindow = new EditLoginWindow();
            editLoginWindow.Name = EditLoginName;
            
            OpenAndTrackWindow(editLoginWindow, false);
        }

        private static void OpenAndTrackWindow(Window window, bool CloseOthers)
        {
            if (WindowIsTracked(window)) return;
            
            window.Show();

            if (CloseOthers) CloseAllWindows();
            
            TrackWindow(window);
        }

        private static void TrackWindow(Window window)
        {
            if (WindowIsTracked(window)) return;
            TrackedWindows.Add(window);
        }

        public static void UnTrackWindow(Window window)
        {
            if (!WindowIsTracked(window)) return;
            TrackedWindows.Remove(window);
        }

        private static void UntrackAllWindows()
        {
            TrackedWindows?.Clear();
        }

        private static bool WindowIsTracked(Window window) => TrackedWindows.Contains(window);
        public static void CloseTrackedWindow(Window window)
        {
            UnTrackWindow(window);
            window.Close();
        }

        public static void CloseAllWindows()
        {
            foreach (var trackedWindow in TrackedWindows)
            {
                trackedWindow.Close();
            }
            UntrackAllWindows();
        }

        private static Window FindWindowWithName(string name)
        {
            foreach (var trackedWindow in TrackedWindows)
            {
                if (trackedWindow.Name == name)
                {
                    return trackedWindow;
                }
            }

            return null;
        }
    }
}