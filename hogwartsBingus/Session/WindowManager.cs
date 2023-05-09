using System;
using System.Security.RightsManagement;
using System.Windows;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.UI_Classes;
using System.Collections.Generic;
using System.Linq;
using hogwartsBingus.Execptions;
using hogwartsBingus.UI_Classes.Profile_UI;
using hogwartsBingus.UI_Classes.TicketBox_UI;
using hogwartsBingus.UI_Classes.TrainStation;

namespace hogwartsBingus.Session
{
    public static class WindowManager
    {
        private static readonly List<Window> TrackedWindows = new List<Window>();
        
        private const string ProfileInfoName = "ProfileInfo", EditLoginName = "EditLogin", 
            MessageBoxName = "MessageBox", TicketBoxName = "TicketBox", ComposeMessageName = "ComposeMessage",
            RequestTicketName = "RequestTicket", TrainStationName = "TrainStation";
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

        public static void OpenTrainStationWindow()
        {
            TrainStationWindow trainStationWindow = new TrainStationWindow();
            try
            {
                OpenSingleInstanceWindow(trainStationWindow, TrainStationName);
            }
            catch (WindowAlreadyOpenException e)
            {
                trainStationWindow.Focus();
            }
        }

        public static void OpenProfileInfoWindow()
        {
            ProfileInfoWindow profileInfoWindow = new ProfileInfoWindow();
            try
            {
                OpenSingleInstanceWindow(profileInfoWindow, ProfileInfoName);
            }
            catch (WindowAlreadyOpenException e)
            {
                profileInfoWindow.Focus();
            }
        }

        public static void OpenEditLoginWindow()
        {
            EditLoginWindow editLoginWindow = new EditLoginWindow();

            try
            {
                OpenSingleInstanceWindow(editLoginWindow, EditLoginName);
            }
            catch (WindowAlreadyOpenException e)
            {
                editLoginWindow.Focus();
            }
        }

        public static void OpenMessageBoxWindow()
        {
            MessageBoxWindow messageBoxWindow = new MessageBoxWindow();
            
            try
            {
                OpenSingleInstanceWindow(messageBoxWindow, MessageBoxName);
            }
            catch (WindowAlreadyOpenException e)
            {
                messageBoxWindow.Focus();
            }
        }

        public static void OpenTicketBoxWindow()
        {
            TicketBoxWindow ticketBoxWindow = new TicketBoxWindow();
            
            try
            {
                OpenSingleInstanceWindow(ticketBoxWindow, TicketBoxName);
            }
            catch (WindowAlreadyOpenException e)
            {
                ticketBoxWindow.Focus();
            }
        }
        
        public static void OpenComposeMessageWindow()
        {
            ComposeMessageWindow composeMessageWindow = new ComposeMessageWindow();
            
            try
            {
                OpenSingleInstanceWindow(composeMessageWindow, ComposeMessageName);
            }
            catch (WindowAlreadyOpenException e)
            {
                composeMessageWindow.Focus();
            }
        }

        public static void OpenRequestTicketWindow()
        {
            RequestTicketWindow requestTicketWindow = new RequestTicketWindow();

            try
            {
                OpenSingleInstanceWindow(requestTicketWindow, RequestTicketName);
            }
            catch (WindowAlreadyOpenException e)
            {
                requestTicketWindow.Focus();
            }
        }

        private static void OpenSingleInstanceWindow(Window window, string name)
        {
            if (FindWindowWithName(name) != null) throw new WindowAlreadyOpenException();

            window.Name = name;
            
            OpenAndTrackWindow(window, false);
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
            for (int i = 0; i < TrackedWindows.Count; i++)
            {
                Window window = TrackedWindows[i];
                TrackedWindows[i] = null;
                window.Close();
                
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

        public static void ThrowError(string message)
        {
            MainWindow mianWindow = new MainWindow();
            mianWindow.Show();
        }
    }
}