using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.Session;

namespace hogwartsBingus.UI_Classes
{
    /// <summary>
    /// Interaction logic for TicketBoxWindow.xaml
    /// </summary>
    public partial class TicketBoxWindow : Window
    {
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
            TicketDescBox.Text = "\n" + ticket.Location + "\n↓\n" + ticket.Destination;
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
