using System;
using System.Windows;
using System.Windows.Input;
using hogwartsBingus.Session;

namespace hogwartsBingus.UI_Classes
{
    public partial class StudentLandingPage : Window
    {        
        public StudentLandingPage()
        {
            InitializeComponent();
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

        }

        private void GoToTrainStationBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GoToHogwartsBtn_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (GoToHogwartsBtn.IsEnabled)
            {
                InfoLabel.Content = "Go to Hogwarts Control Panel";
                return;
            }

            InfoLabel.Content = "You are not currently in hogwarts, hence you cannot access this panel";
        }

        private void GoToTrainStationBtn_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            InfoLabel.Content = "Go to your local train station";
        }

        private void ClearDescriptionText(object sender, System.Windows.Input.MouseEventArgs e)
        {
            InfoLabel.Content = "";
        }

        private void StudentLandingPage_OnClosed(object sender, EventArgs e)
        {
            WindowManager.UnTrackWindow(this);
        }
    }
}