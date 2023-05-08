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
    /// Interaction logic for ProfileInfoWindow.xaml
    /// </summary>
    public partial class ProfileInfoWindow : Window
    {
        public ProfileInfoWindow()
        {
            InitializeComponent();
        }

        private void ProfileInfoWindow_OnClosed(object sender, EventArgs e)
        {
            WindowManager.UnTrackWindow(this);
        }

        private void SetInfoBoxContent()
        {
            string[] generalInfo = SessionManager.GetGeneralUserInfo();
            InfoBlock.Text = generalInfo[0];
        }

        private void CloseBtn_OnClick(object sender, RoutedEventArgs e)
        {
            WindowManager.UnTrackWindow(this);
        }

        private void EditLoginBtn_OnClick(object sender, RoutedEventArgs e)
        {
            WindowManager.OpenEditLoginWindow();
        }
    }
}
