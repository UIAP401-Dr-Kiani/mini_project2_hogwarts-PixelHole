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
using hogwartsBingus.DataStorage;
using hogwartsBingus.Session;
using Microsoft.Win32;

namespace hogwartsBingus.UI_Classes
{
    /// <summary>
    /// Interaction logic for ComposeMessageWindow.xaml
    /// </summary>
    public partial class ComposeMessageWindow : Window
    {
        private int ReceiverIndex;
        public ComposeMessageWindow(string receiver)
        {
            InitializeComponent();
            ReceiverNameField.Text = receiver;
        }

        private void ComposeMessageWindow_OnClosed(object sender, EventArgs e)
        {
            WindowManager.UnTrackWindow(this);
        }

        private void SendBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (ReceiverIndex == -1) return;
            
            Message message = new Message(SenderNameField.Text, ReceiverNameField.Text, TitleField.Text,MessageContentField.Text);

            MessagingHandler.SendMessageTo(message, ReceiverIndex);

            LogLabel.Content = "Message Sent!";
            
            ClearAllFields();
        }

        private void ClearAllFields()
        {
            SenderNameField.Text = "";
            ReceiverNameField.Text = "";
            MessageContentField.Text = "";
            TitleField.Text = "";
        }
        
        private void ReceiverNameField_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ReceiverIndex = UserManager.FindWithName(ReceiverNameField.Text);
            ChangeReceiverNameColor();
        }

        private void ChangeReceiverNameColor()
        {
            if (ReceiverIndex != -1)
            {
                ReceiverNameField.Foreground = new SolidColorBrush(Color.FromRgb(80, 250, 123));
                return;
            }
            
            ReceiverNameField.Foreground = new SolidColorBrush(Color.FromRgb(255, 85, 85));
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.CloseTrackedWindow(this);
        }
    }
}
