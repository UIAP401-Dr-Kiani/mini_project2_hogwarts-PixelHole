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
using hogwartsBingus.Session;

namespace hogwartsBingus.UI_Classes
{
    /// <summary>
    /// Interaction logic for TicketBoxWindow.xaml
    /// </summary>
    public partial class TicketBoxWindow : Window
    {
        public TicketBoxWindow()
        {
            InitializeComponent();
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
    }
}
