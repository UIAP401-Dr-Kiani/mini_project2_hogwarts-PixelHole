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

namespace hogwartsBingus.UI_Classes.Profile_UI
{
    /// <summary>
    /// Interaction logic for EditLoginWindow.xaml
    /// </summary>
    public partial class EditLoginWindow : Window
    {
        public EditLoginWindow()
        {
            InitializeComponent();
        }

        private void EditLoginWindow_OnLostFocus(object sender, RoutedEventArgs e)
        {
            Focus();
        }

        private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            WindowManager.UnTrackWindow(this);
        }

        private void ConfirmBtn_OnClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
