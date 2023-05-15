using System;
using System.Windows;
using System.Windows.Input;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.Session;

namespace hogwartsBingus.UI_Classes.LandingPages
{
    public partial class LandingPage
    {        
        public LandingPage()
        {
            InitializeComponent();
            CheckLocation();
        }

        private void ShowProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.OpenProfileInfoWindow();
        }

        private void ShowMessageBoxBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.OpenMessageBoxWindow();
        }

        private void ShowTicketsBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.OpenTicketBoxWindow();
        }

        private void GoToHogwartsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SessionManager.GetUserFaction() != null)
            {
                if (SessionManager.GetUserFaction().Value == FactionType.None)
                {
                    WindowManager.OpenFactionAssignmentWindow();
                    return;
                }
            }
            WindowManager.LaunchHogwartsPageOfType(SessionManager.GetUserType());
        }

        private void GoToTrainStationBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.OpenTrainStationWindow();
        }

        private void GoToHogwartsBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            if (GoToHogwartsBtn.IsEnabled)
            {
                InfoLabel.Content = "Go to Hogwarts Control Panel";
                return;
            }

            InfoLabel.Content = "You are not currently in hogwarts, hence you cannot access this panel";
        }

        private void GoToTrainStationBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            InfoLabel.Content = "Go to your local train station";
        }

        private void ClearDescriptionText(object sender, MouseEventArgs e)
        {
            InfoLabel.Content = "";
        }

        private void StudentLandingPage_OnClosed(object sender, EventArgs e)
        {
            WindowManager.UnTrackWindow(this);
        }

        private void LogOutBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.LaunchLoginPage();
        }

        private void CheckLocation()
        {
            if (SessionManager.GetUserLocation() == Location.HogwartsUniversity)
            {
                GoToHogwartsBtn.IsEnabled = true;
                return;
            }

            GoToHogwartsBtn.IsEnabled = false;
        }

        private void StudentLandingPage_OnMouseEnter(object sender, MouseEventArgs e)
        {
            CheckLocation();
        }
    }
}