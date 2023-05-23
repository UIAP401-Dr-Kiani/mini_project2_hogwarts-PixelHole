using System;
using System.Windows;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.UI_Classes;
using System.Collections.Generic;
using hogwartsBingus.Execptions;
using hogwartsBingus.UI_Classes.Profile_UI;
using hogwartsBingus.UI_Classes.TicketBox_UI;
using hogwartsBingus.UI_Classes.TrainStation;
using hogwartsBingus.UI_Classes.Ceremony;
using hogwartsBingus.UI_Classes.Dialogs;
using hogwartsBingus.UI_Classes.Hogwarts;
using hogwartsBingus.UI_Classes.Hogwarts.Dumbledore_Specific;
using hogwartsBingus.UI_Classes.Hogwarts.Professor_Specific;
using hogwartsBingus.UI_Classes.Hogwarts.Professor_Specific.Subject_Config;
using hogwartsBingus.UI_Classes.Hogwarts.Student_Specific;
using hogwartsBingus.UI_Classes.LandingPages;
using hogwartsBingus.University.Excercies;
using Microsoft.Win32;

namespace hogwartsBingus.Session
{
    public static class WindowManager
    {
        private static readonly List<Window> TrackedWindows = new List<Window>();

        private const string
            ProfileInfoName = "ProfileInfo",
            EditLoginName = "EditLogin",
            MessageBoxName = "MessageBox",
            TicketBoxName = "TicketBox",
            ComposeMessageName = "ComposeMessage",
            RequestTicketName = "RequestTicket",
            TrainStationName = "TrainStation",
            UpdateScheduleName = "Updateschedule",
            FactionAssignmentName = "FactionAssignment",
            WeeklyScheduleName = "WeeklySchedule",
            SaveDialogName = "SaveDialog",
            LoadDialogName = "LoadDialog",
            ExerciseConfigName = "ExerciseConfig",
            BedNumberAssignmentName = "BedNumberAssignment",
            DormitoryConfigName = "DormitoryConfig",
            SubjectConfigName = "SubjectConfig";
            
        
        delegate void IfWindowOpen();
        public static void AppStartup()
        {
            LaunchLoginPage();
        }
        public static void AppEnd()
        {
        }
        private static void AppEndTrigger()
        {
            if (NoWindowsOpen())
            {
                AppEnd();
            }
        }
        public static void LaunchLoginPage()
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            
            CloseAllWindows();
            TrackWindow(loginWindow);
        }
        public static void LaunchLandingPage()
        {
            LandingPage landingPage = new LandingPage();
            OpenAndTrackWindow(landingPage, true);
        }
        public static void LaunchHogwartsPageOfType(AuthorizationType type)
        {
            switch (type)
            {
                case AuthorizationType.Student:
                    StudentHogwartsWindow studentHogwartsWindow = new StudentHogwartsWindow();
                    OpenAndTrackWindow(studentHogwartsWindow, true);
                    break;
                
                case AuthorizationType.Professor:
                    ProfessorHogwartsWindow professorHogwartsWindow = new ProfessorHogwartsWindow();
                    OpenAndTrackWindow(professorHogwartsWindow, true);
                    break;
                
                case AuthorizationType.Dumbledore:
                    DumbledoreHogwartsWindow dumbledoreHogwartsWindow = new DumbledoreHogwartsWindow();
                    OpenAndTrackWindow(dumbledoreHogwartsWindow, true);
                    break;
                default:
                    throw new InvalidAuthorizationTypeException("the Authorized person's type not recognised");
            }
        }

        
        // single instance window handling
        public static void OpenAddDormitoryWindow()
        {
            DormitoryConfigWindow dormitoryConfigWindow = new DormitoryConfigWindow();
            OpenSingleInstanceWindow(dormitoryConfigWindow, DormitoryConfigName, () => FocusWindow(dormitoryConfigWindow));
        }
        public static void OpenBedNumberAssignmentWindow()
        {
            BedAssignmentWindow bedAssignmentWindow = new BedAssignmentWindow();
            OpenSingleInstanceWindow(bedAssignmentWindow, BedNumberAssignmentName, () => FocusWindow(bedAssignmentWindow));
        }
        public static void OpenWeeklyScheduleWindow()
        {
            UserWeeklyScheduleWindow weeklyScheduleWindow = new UserWeeklyScheduleWindow();
            OpenSingleInstanceWindow(weeklyScheduleWindow, WeeklyScheduleName, () => FocusWindow(weeklyScheduleWindow));
        }
        public static void OpenFactionAssignmentWindow()
        {
            FactionAssignmentWindow factionAssignmentWindow = new FactionAssignmentWindow();
            OpenSingleInstanceWindow(factionAssignmentWindow, FactionAssignmentName, () => FocusWindow(factionAssignmentWindow));
        }
        public static void OpenUpdateScheduleWindow()
        {
            UpdateScheduleUpdaterWindow updateScheduleUpdaterWindow = new UpdateScheduleUpdaterWindow();
            OpenSingleInstanceWindow(updateScheduleUpdaterWindow, UpdateScheduleName, () => FocusWindow(updateScheduleUpdaterWindow));
        }
        public static void OpenTrainStationWindow()
        {
            TrainStationWindow trainStationWindow = new TrainStationWindow();
            
            OpenSingleInstanceWindow(trainStationWindow, TrainStationName, () => FocusWindow(trainStationWindow));
        }
        public static void OpenProfileInfoWindow()
        {
            ProfileInfoWindow profileInfoWindow = new ProfileInfoWindow();
            
            OpenSingleInstanceWindow(profileInfoWindow, ProfileInfoName, () => FocusWindow(profileInfoWindow));
        }
        public static void OpenEditLoginWindow()
        {
            EditLoginWindow editLoginWindow = new EditLoginWindow();

            OpenSingleInstanceWindow(editLoginWindow, EditLoginName, () => FocusWindow(editLoginWindow));
        }
        public static void OpenMessageBoxWindow()
        {
            MessageBoxWindow messageBoxWindow = new MessageBoxWindow();
            
            OpenSingleInstanceWindow(messageBoxWindow, MessageBoxName, () => FocusWindow(messageBoxWindow));
        }
        public static void OpenTicketBoxWindow()
        {
            TicketBoxWindow ticketBoxWindow = new TicketBoxWindow();
            
            OpenSingleInstanceWindow(ticketBoxWindow, TicketBoxName, () => FocusWindow(ticketBoxWindow));
        }
        public static void OpenComposeMessageWindow(string receiver)
        {
            ComposeMessageWindow composeMessageWindow = new ComposeMessageWindow(receiver);

            OpenSingleInstanceWindow(composeMessageWindow, ComposeMessageName, () => FocusWindow(composeMessageWindow));
        }
        public static void OpenRequestTicketWindow()
        {
            RequestTicketWindow requestTicketWindow = new RequestTicketWindow();

            OpenSingleInstanceWindow(requestTicketWindow, RequestTicketName, () => FocusWindow(requestTicketWindow));
        }
        public static void OpenExerciseEditWindow(string subjectName, string exercise)
        {
            ExerciseConfigWindow exerciseConfigWindow = new ExerciseConfigWindow(subjectName, exercise);
            OpenSingleInstanceWindow(exerciseConfigWindow, ExerciseConfigName, () => FocusWindow(exerciseConfigWindow));
        }
        public static void OpenExerciseAddWindow(string subjectName)
        {
            ExerciseConfigWindow exerciseConfigWindow = new ExerciseConfigWindow(subjectName);
            OpenSingleInstanceWindow(exerciseConfigWindow, ExerciseConfigName, () => FocusWindow(exerciseConfigWindow));
        }
        public static void OpenAddSubjectWindow()
        {
            SubjectConfigWindow subjectConfigWindow = new SubjectConfigWindow();
            OpenSingleInstanceWindow(subjectConfigWindow, DormitoryConfigName, () => FocusWindow(subjectConfigWindow));
        }

        private static void OpenSingleInstanceWindow(Window window, string name, IfWindowOpen ifWindowOpen)
        {
            if (FindWindowWithName(name) != null)
            {
                ifWindowOpen();
                return;
            }

            window.Name = name;
            
            OpenAndTrackWindow(window, false);
        }

        
        // Dialog Windows
        public static void OpenSaveDialog(bool autoClose)
        {
            SavingDataDialog savingDataDialog = new SavingDataDialog(autoClose);
            OpenSingleInstanceWindow(savingDataDialog, SaveDialogName, (() => FocusWindow(savingDataDialog)));
        }
        public static void SetSaveDialogProgress(int progress)
        {
            SavingDataDialog saveDialog = FindWindowWithName(SaveDialogName) as SavingDataDialog;
            saveDialog?.SetProgress(progress);
        }
        public static void OpenLoadDialog(bool autoClose)
        {
            LoadingDataDialog loadDialog = new LoadingDataDialog(autoClose);
            OpenSingleInstanceWindow(loadDialog, LoadDialogName, () => FocusWindow(loadDialog));
        }
        public static void SetLoadDialogProgress(int progress)
        {
            LoadingDataDialog loadDialog = FindWindowWithName(LoadDialogName) as LoadingDataDialog;
            loadDialog?.SetProgress(progress);
        }
        
        // tracking and un-tracking
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
        
        
        // track check
        private static bool WindowIsTracked(Window window) => TrackedWindows.Contains(window);
        private static bool NoWindowsOpen() => TrackedWindows.Count == 0;
        
        
        // closing windows
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
        
        
        // opening windows
        private static void OpenAndTrackWindow(Window window, bool closeOthers)
        {
            if (WindowIsTracked(window)) return;
            
            window.Show();

            if (closeOthers) CloseAllWindows();
            
            TrackWindow(window);
        }
        
        
        // find window
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
        
        
        // focusing windows
        private static void FocusWindow(Window window)
        {
            window.Topmost = true;
            window.Topmost = false;
        }

        
        // Debugging
        public static void ThrowError(string message)
        {
            MainWindow mianWindow = new MainWindow();
            mianWindow.Show();
        }
    }
}