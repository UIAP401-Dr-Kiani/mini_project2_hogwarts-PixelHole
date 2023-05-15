using System;
using System.Windows;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.Session;

namespace hogwartsBingus.UI_Classes.Hogwarts
{
    /// <summary>
    /// Interaction logic for StudentWeeklyScheduleWindow.xaml
    /// </summary>
    public partial class UserWeeklyScheduleWindow : Window
    {
        private WeeklySchedule Schedule;
        public UserWeeklyScheduleWindow()
        {
            InitializeComponent();
            GetSchedule();
            UpdateWeeklyScheduleDisplay();
        }

        private void GetSchedule()
        {
            Schedule = SessionManager.GetWeeklySchedule();
        }

        private void UpdateWeeklyScheduleDisplay()
        {
            WeeklyScheduleTable.ItemsSource = GenerateScheduleDisplayContent();
        }

        private string[] GenerateScheduleDisplayContent()
        {
            string[] content = new string[6 * 11];

            for (int i = 1; i < 11; i++)
            {
                content[i] = $"{7 + i} - {8 + i}";
            }

            for (int i = 1; i < 6; i++)
            {
                content[i * 11] = Enum.GetName(typeof(Day), (i + 1));
            }

            foreach (var subject in Schedule.Subjects)
            {
                foreach (var session in subject.Sessions)
                {
                    int index = TimeSpanToDisplayTableIndex(session.StartTime);
                    for (int i = 0; i < session.Duration.Hours; i++)
                    {
                        content[index + i] = subject.Name;
                    }
                }
            }

            return content;
        }

        private int TimeSpanToDisplayTableIndex(TimeSpan time)
        {
            int x = time.Hours - 7;
            int y = time.Days - 2;
            return x + y * 11;
        }

        private void StudentWeeklyScheduleWindow_OnClosed(object sender, EventArgs e)
        {
            WindowManager.UnTrackWindow(this);
        }
    }
}
