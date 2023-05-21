using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.DataStorage;
using hogwartsBingus.Session;

namespace hogwartsBingus.UI_Classes.TicketBox_UI
{
    /// <summary>
    /// Interaction logic for RequestTicketWindow.xaml
    /// </summary>
    public partial class RequestTicketWindow : Window
    {
        private Location Location, Destination;
        private DateTime time;
        private int SenderIndex;
        
        Regex timeFormat = new Regex(@"([01][01]?[0-9]|2[0-3]):[0-5][0-9]");
        Regex dateFormat = new Regex(@"^\d{4}\-(0?[1-9]|1[012])\-(0?[1-9]|[12][0-9]|3[01])$");
        public RequestTicketWindow()
        {
            InitializeComponent();
        }

        private void LocationField_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateLocation();
            UpdateFieldColors();
        }

        private void DestinationField_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateDestination();
            UpdateFieldColors();
        }

        private void SenderNameField_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateSenderIndex();
            UpdateFieldColors();
        }

        private void UpdateSenderIndex() => SenderIndex = UserManager.FindWithName(SenderNameField.Text);

        private void UpdateLocation()
        {
            try
            {
                Location = (Location)Enum.Parse(typeof(Location), LocationField.Text);
            }
            catch (Exception)
            {
                Location = Location.None;
            }
        }

        private void UpdateDestination()
        {
            try
            {
                Destination = (Location)Enum.Parse(typeof(Location), DestinationField.Text);
            }
            catch (Exception)
            {
                Destination = Location.None;
            }
        }

        private void UpdateTime()
        {
            if (!timeFormat.IsMatch(TimeField.Text) && dateFormat.IsMatch(DateField.Text))
            {
                time = DateTime.MinValue;
                return;
            }

            string[] dateString = DateField.Text.Split('-'),
                timeString = TimeField.Text.Split(':');

            time = new DateTime(int.Parse(dateString[0]), int.Parse(dateString[1]), int.Parse(dateString[2]),
                int.Parse(timeString[0]), int.Parse(timeString[1]), 0);
        }

        private void UpdateFieldColors()
        {
            if (Location == Location.None)
            {
                LocationField.Foreground = DraculaThemeColors.RedBrush;
            }
            else
            {
                LocationField.Foreground = DraculaThemeColors.GreenBrush;
            }

            if (Destination == Location.None)
            {
                DestinationField.Foreground = DraculaThemeColors.RedBrush;
            }
            else
            {
                DestinationField.Foreground = DraculaThemeColors.GreenBrush;
            }

            if (SenderIndex == -1)
            {
                SenderNameField.Foreground = DraculaThemeColors.RedBrush;
            }
            else
            {
                SenderNameField.Foreground = DraculaThemeColors.GreenBrush;
            }
        }

        private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            WindowManager.CloseTrackedWindow(this);
        }

        private void SubmitBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (Location == Location.None || Destination == Location.None || SenderIndex == -1 || time == DateTime.MinValue) return;

            try
            {
                TicketRequestHandler.RequestTicket(new TicketRequest(SenderNameField.Text, Location, Destination, time));
            }
            catch (Exception)
            {
                //display on Error Label
            }
            
            WindowManager.CloseTrackedWindow(this);
        }

        private void TimeField_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!timeFormat.IsMatch(TimeField.Text))
            {
                TimeField.Foreground = DraculaThemeColors.RedBrush;
                return;
            }
            
            TimeField.Foreground = DraculaThemeColors.GreenBrush;
            UpdateTime();
        }
        private void DateField_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!dateFormat.IsMatch(DateField.Text))
            {
                DateField.Foreground = DraculaThemeColors.RedBrush;
                return;
            }
            
            DateField.Foreground = DraculaThemeColors.GreenBrush;
            UpdateTime();
        }
    }
}
