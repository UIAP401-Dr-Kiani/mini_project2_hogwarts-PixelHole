using hogwartsBingus.Base_Classes;
using hogwartsBingus.Session;
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

namespace hogwartsBingus.UI_Classes.Hogwarts.Student_Specific
{
    /// <summary>
    /// Interaction logic for StudentWeeklyScheduleWindow.xaml
    /// </summary>
    public partial class StudentWeeklyScheduleWindow : Window
    {
        private WeeklySchedule Schedule;
        public StudentWeeklyScheduleWindow()
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
