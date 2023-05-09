using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.Session;

namespace hogwartsBingus.UI_Classes.TicketBox_UI
{
    /// <summary>
    /// Interaction logic for TicketBoxWindow.xaml
    /// </summary>
    public partial class TicketBoxWindow
    {
        // ReSharper disable once InconsistentNaming
        private List<TrainTicket> tickets = new List<TrainTicket>();
        public TicketBoxWindow()
        {
            InitializeComponent();
            UpdateTickets();
            UpdateTicketsView();
        }

        private void UpdateTickets()
        {
            tickets = SessionManager.GetTickets();
        }

        private void UpdateTicketsView()
        {
            List<string> titles = new List<string>();

            foreach (var ticket in tickets)
            {
                titles.Add(ticket.Location + "→" + ticket.Destination + " : " + ticket.MoveTime.Year + " / " 
                           + ticket.MoveTime.Month + " / " + ticket.MoveTime.Date);
            }

            TicketsList.ItemsSource = titles;
        }

        private void SetTicketDescriptionText()
        {
            TrainTicket ticket = tickets[TicketsList.SelectedIndex];
            TicketDescBox.Text = GenerateTicketDisplayText(ticket);
        }

        private string GenerateTicketDisplayText(TrainTicket ticket)
        {
            return
                $"\n{ticket.Location}\n↓\n{ticket.Destination}\n\n" +
                $"{ticket.MoveTime.Year}/{ticket.MoveTime.Month}/{ticket.MoveTime.Day}\n" +
                $"{ticket.MoveTime.DayOfWeek}\n" +
                $"{ticket.MoveTime.TimeOfDay}";
        }

        private void TicketBoxWindow_OnClosed(object sender, EventArgs e)
        {
            WindowManager.CloseTrackedWindow(this);
        }

        private void RequestTicketBtn_OnClick(object sender, RoutedEventArgs e)
        {
            WindowManager.OpenRequestTicketWindow();
        }

        private void CloseBtn_OnClick(object sender, RoutedEventArgs e)
        {
            WindowManager.CloseTrackedWindow(this);
        }

        private void TicketsList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetTicketDescriptionText();
        }
    }
}
