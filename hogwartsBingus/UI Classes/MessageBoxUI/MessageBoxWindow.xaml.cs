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
        public MessageBoxWindow()
        {
            InitializeComponent();
            
            UpdateMessageList();

            MessagingHandler.MessageSent += UpdateMessageList;
        }

        private void UpdateMessageList()
        {
            List<string> Titles = new List<string>();

            List<Message> messages = SessionManager.GetMessageList();

            if (messages == null)
            {
                MessageList.ItemsSource = Titles;
                return;
            }
            
            foreach (var message in messages)
            {
                Titles.Add(message.Title);
            }

            MessageList.ItemsSource = Titles;
        }
        private void MessageBoxWindow_OnClosed(object sender, EventArgs e)
        {
            WindowManager.UnTrackWindow(this);
            MessagingHandler.MessageSent -= UpdateMessageList;
        }

        private void BackBtn_OnClick(object sender, RoutedEventArgs e)
        {
            WindowManager.CloseTrackedWindow(this);
        }

        private void ComposeMessageBtn_OnClick(object sender, RoutedEventArgs e)
        {
            WindowManager.OpenComposeMessageWindow("");
        }

        private void MessageList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MessageList.SelectedItem == null) return;
            
            Message message = SessionManager.GetMessageWithTitle(MessageList.SelectedItem.ToString());
            MessageContentBox.Text = GenerateDisplayMessageText(message);
        }

        private string GenerateDisplayMessageText(Message message)
        {
            return $"From : {message.Sender}\tTo : {message.Receiver}\n\n{message.Title}\n\n{message.Text}";
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Message message = SessionManager.GetMessageWithTitle(MessageList.SelectedItem.ToString());
            SessionManager.RequestRemoveMessage(message);
            
            UpdateMessageList();
            ClearMessageContentLabel();
        }
        private void ClearMessageContentLabel()
        {
            MessageContentBox.Text = "";
        }
    }
}
