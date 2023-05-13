using System;
using System.Collections.Generic;
using System.Windows;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.Session;
using hogwartsBingus.University;

namespace hogwartsBingus.UI_Classes.TrainStation
{
    /// <summary>
    /// Interaction logic for TrainStationWindow.xaml
    /// </summary>
    public partial class TrainStationWindow : Window
    {
        private List<TrainTicket> UsefulTickets = new List<TrainTicket>();
        public TrainStationWindow()
        {
            InitializeComponent();
            UpdateWindowContent();

            GlobalClock.TimeChanged += UpdateTimeLabel;
        }

        private void UpdateWindowContent()
        {
            UpdateTimeLabel();
            UpdateLocationLabel();
            UpdateUsefulTicketsList();
            UpdateTrainsList();
        }

        private void UpdateTimeLabel()
        {
            TimeLabel.Content = GlobalClock.GetCurrentTimeString();
        }

        private void UpdateLocationLabel()
        {
            LocationLabel.Content = SessionManager.GetUserLocation();
        }

        private void UpdateTrainsList()
        {
            TrainsList.ItemsSource = GenerateTrains();
        }

        private void TrainStationWindow_OnClosed(object sender, EventArgs e)
        {
            WindowManager.UnTrackWindow(this);
        }

        private void TicketsBtn_OnClick(object sender, RoutedEventArgs e)
        {
            WindowManager.OpenTicketBoxWindow();
        }

        private void UpdateUsefulTicketsList()
        {
            UsefulTickets.Clear();
            foreach (var ticket in SessionManager.GetTickets())
            {
                //this check shouldn't be here, move it in future commits
                if (ticket.Location.ToString() == (SessionManager.GetUserLocation()).ToString() && 
                    GlobalClock.CurrentTime > ticket.MoveTime.Subtract(new TimeSpan(0, 1, 0, 0)) &&
                    GlobalClock.CurrentTime < ticket.MoveTime.AddMinutes(10))
                {
                    UsefulTickets.Add(ticket);
                }
            }
        }
        private List<string> GenerateTrains()
        {
            List<string> trains = new List<string>();
            foreach (var ticket in UsefulTickets)
            {
                trains.Add($"Train No.{ticket.TrainNumber} : {ticket.MoveTime.TimeOfDay}   " +
                           $"From : {ticket.Location.ToString()}  To : {ticket.Destination.ToString()}");
            }

            return trains;
        }

        private void BoardBtn_OnClick(object sender, RoutedEventArgs e)
        {
            SessionManager.RequestTransport(UsefulTickets[TrainsList.SelectedIndex]);
            UpdateWindowContent();
        }
    }
}
