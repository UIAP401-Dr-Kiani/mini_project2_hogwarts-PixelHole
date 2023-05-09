using System;
using System.Collections.Generic;
using System.Windows;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.Session;
using DateTime = hogwartsBingus.Base_Classes.DateTime;

namespace hogwartsBingus.UI_Classes.TrainStation
{
    /// <summary>
    /// Interaction logic for TrainStationWindow.xaml
    /// </summary>
    public partial class TrainStationWindow : Window
    {
        public TrainStationWindow()
        {
            InitializeComponent();
            UpdateTimeLabel();
            UpdateLocationLabel();

            GlobalClock.TimeChanged += UpdateTimeLabel;
        }

        private void UpdateTimeLabel()
        {
            TimeLabel.Content = GlobalClock.GetCurrentTimeString();
        }

        private void UpdateLocationLabel()
        {
            LocationLabel.Content = SessionManager.UserLocation;
        }

        private void TrainStationWindow_OnClosed(object sender, EventArgs e)
        {
            WindowManager.UnTrackWindow(this);
        }

        private void TicketsBtn_OnClick(object sender, RoutedEventArgs e)
        {
            WindowManager.OpenTicketBoxWindow();
        }

        private static List<string> GenerateTrains()
        {
            List<string> trains = new List<string>();
            foreach (var ticket in SessionManager.GetTickets())
            {
                if (ticket.Location == SessionManager.UserLocation && 
                    GlobalClock.CurrentTime >
                    ticket.MoveTime -
                    new hogwartsBingus.Base_Classes.DateTime(0,
                        0,
                        0,
                        Day.None,
                        1,
                        0) &&
                    GlobalClock.CurrentTime < ticket.MoveTime)
                {
                    
                }
            }

            return trains;
        }
    }
}
