using System;
using Terminal.Gui;
using TerminalGUI;

Application.Run<MainWindow>();

Application.Shutdown();

namespace TerminalGUI
{
    public class MainWindow : Window
    {
        private Window WriteWindow = new WriteEmailWindow();
        public MainWindow()
        {
            Email[] emails = new Email[4];

            for (int i = 0; i < emails.Length; i++)
            {
                emails[i] = new Email("kos" + i.ToString(), "koon" + i.ToString());
            }

            ListView emailTitles = new ListView()
            {
                X = 0,
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Fill(),
            };
            
            FrameView inboxTitlesView = new FrameView("Titles")
            {
                X = 0,
                Y = 0,
                Width = Dim.Percent(20, true),
                Height = Dim.Percent(95, true),
            };
            
            TextView emailMessage = new TextView()
            {
                X = 0,
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Fill(),
            };

            FrameView messagesView = new FrameView("Content")
            {
                X = Pos.Right(inboxTitlesView),
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Percent(95, true),
            };
            Button writeBtn = new Button()
            {
                X = Pos.X(inboxTitlesView),
                Y = Pos.Bottom(inboxTitlesView),
                Width = Dim.Width(inboxTitlesView),
                Height = Dim.Fill(),
                Text = "Write an Email",
            };

            string[] titles = new string[emails.Length];
            for (int i = 0; i < emails.Length; i++) titles[i] = emails[i].title;
            string[] messages = new string[emails.Length];
            for (int i = 0; i < emails.Length; i++) messages[i] = emails[i].message;
            
            emailTitles.SetSource(titles);
            
            emailTitles.SelectedItemChanged += s => emailMessage.Text = messages[emailTitles.SelectedItem];

            writeBtn.Clicked += () => Application.Run<WriteEmailWindow>();

            Add(inboxTitlesView, messagesView, writeBtn);
            inboxTitlesView.Add(emailTitles);
            messagesView.Add(emailMessage);
        }
    }

    class WriteEmailWindow : Window
    {
        public WriteEmailWindow()
        {
            FrameView MessageView = new FrameView()
            {
                X = 0,
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Percent(95, true),
            };
            TextView messageBox = new TextView()
            {
                X = 0,
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Fill(),
            };
            Button sendBtn = new Button()
            {
                Text = "Send",
                X = 0,
                Y = Pos.Bottom(MessageView),
                Width = Dim.Percent(20, true),
                Height = Dim.Fill()
            };
            Button resetBtn = new Button()
            {
                Text = "Reset",
                X = Pos.Right(sendBtn),
                Y = Pos.Bottom(MessageView),
                Width = Dim.Percent(20),
                Height = Dim.Fill()
            };
            
            Add(MessageView, sendBtn, resetBtn);
            MessageView.Add(messageBox);
        }
    }
    class Email
    {
        public string title;
        public string message;

        public Email(string title, string message)
        {
            this.title = title;
            this.message = message;
        }
    }
}