using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.DataStorage;
using hogwartsBingus.Session;

namespace hogwartsBingus.UI_Classes
{
    /// <summary>
    /// Interaction logic for MessageBoxWindow.xaml
    /// </summary>
    public partial class MessageBoxWindow : Window
    {
        private List<Message> Messages = new List<Message>();
        public MessageBoxWindow()
        {
            InitializeComponent();
            
            UpdateMessages();
            UpdateMessageList();
        }
        private void UpdateMessages()
        {
            Messages = SessionManager.GetMessageList();
        }

        private void UpdateMessageList()
        {
            List<string> Titles = new List<string>();

            foreach (var message in Messages)
            {
                Titles.Add(message.Title);
            }

            MessageList.ItemsSource = Titles;
        }
        private void MessageBoxWindow_OnClosed(object sender, EventArgs e)
        {
            WindowManager.UnTrackWindow(this);
        }

        private void BackBtn_OnClick(object sender, RoutedEventArgs e)
        {
            WindowManager.CloseTrackedWindow(this);
        }

        private void ComposeMessageBtn_OnClick(object sender, RoutedEventArgs e)
        {
            WindowManager.OpenComposeMessageWindow();
        }

        private void MessageList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageContentBox.Text = GenerateDisplayMessageText(Messages[MessageList.SelectedIndex]);
        }

        private string GenerateDisplayMessageText(Message message)
        {
            return $"From : {message.Sender}\tTo : {message.Receiver}\n\n{message.Title}\n\n{message.Text}";
        }
    }
}
