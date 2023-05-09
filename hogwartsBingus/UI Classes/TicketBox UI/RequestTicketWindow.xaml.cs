using System;
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
        private int SenderIndex;
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
            catch (Exception e)
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
            catch (Exception e)
            {
                Destination = Location.None;
            }
        }

        private void UpdateFieldColors()
        {
            if (Location == Location.None)
            {
                LocationField.Foreground = new SolidColorBrush(DraculaThemeColors.Red);
            }
            else
            {
                LocationField.Foreground = new SolidColorBrush(DraculaThemeColors.Green);
            }

            if (Destination == Location.None)
            {
                DestinationField.Foreground = new SolidColorBrush(DraculaThemeColors.Red);
            }
            else
            {
                DestinationField.Foreground = new SolidColorBrush(DraculaThemeColors.Green);
            }

            if (SenderIndex == -1)
            {
                SenderNameField.Foreground = new SolidColorBrush(DraculaThemeColors.Red);
            }
            else
            {
                SenderNameField.Foreground = new SolidColorBrush(DraculaThemeColors.Green);
            }
        }

        private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            WindowManager.CloseTrackedWindow(this);
        }

        private void SubmitBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (Location == Location.None || Destination == Location.None || SenderIndex == -1) return;

            try
            {
                TicketRequestHandler.RequestTicket(new TicketRequest(SenderNameField.Text, Location, Destination));
            }
            catch (Exception exception)
            {
                //display on Error Label
            }
            
            WindowManager.CloseTrackedWindow(this);
        }
    }
}
