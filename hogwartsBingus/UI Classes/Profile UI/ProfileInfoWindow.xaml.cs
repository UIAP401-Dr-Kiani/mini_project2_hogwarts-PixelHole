using System;
using System.Text;
using System.Windows;
using hogwartsBingus.Base_Classes;
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
            SetInfoBoxContent();
        }

        private void ProfileInfoWindow_OnClosed(object sender, EventArgs e)
        {
            WindowManager.UnTrackWindow(this);
        }

        private void SetInfoBoxContent()
        {
            string[] generalInfo = SessionManager.GetGeneralUserInfo();

            StringBuilder finalText = new StringBuilder("");

            finalText.Append($"{generalInfo[0]}\n{generalInfo[2]}\n\nBorn : {generalInfo[1]}\n\n" +
                             $"{generalInfo[3].Replace('_', ' ')}");
            
            if (generalInfo[4] != null)
            {
                finalText.Append($"\n\nFather : {generalInfo[4]}");
            }

            finalText.Append($"\n\nID : {generalInfo[5]}\n\nAssigned Pet : {generalInfo[6]}");

            switch (SessionManager.UserType)
            {
                case AuthorizationType.Student:
                    finalText.Append($"\n\nHouse : {generalInfo[7]}\n\nDormitory Number : ");
                    
                    if (generalInfo[8] != "0")
                    {
                        finalText.Append(generalInfo[8]);
                        break;
                    }

                    finalText.Append("Not Assigned");
                    break;
                case AuthorizationType.Professor:
                    break;
            }

            InfoBlock.Text = finalText.ToString();
        }

        private void CloseBtn_OnClick(object sender, RoutedEventArgs e)
        {
            WindowManager.CloseTrackedWindow(this);
        }

        private void EditLoginBtn_OnClick(object sender, RoutedEventArgs e)
        {
            WindowManager.OpenEditLoginWindow();
        }
    }
}
