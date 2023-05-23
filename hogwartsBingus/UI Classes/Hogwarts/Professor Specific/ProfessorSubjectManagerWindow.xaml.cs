using System;
using System.Windows;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.DataStorage;
using hogwartsBingus.Session;

namespace hogwartsBingus.UI_Classes.Hogwarts.Professor_Specific
{
    /// <summary>
    /// Interaction logic for ProfessorSubjectManagerWindow.xaml
    /// </summary>
    public partial class ProfessorSubjectManagerWindow
    {
        private WeeklySchedule Schedule = new WeeklySchedule();
        
        public ProfessorSubjectManagerWindow()
        {
            InitializeComponent();
            UpdateSchedule();
            UpdateWeeklyScheduleDisplay();
        }
        
        private void UpdateSchedule()
        {
            Schedule.Subjects.Clear();

            foreach (var subject in SubjectManager.FindSubjectsWithProfessor(SessionManager.GetUserFullName()))
            {
                Schedule.Subjects.Add(subject);
            }
        }
        
        
        // Update Schedule Display
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
        
        
        // Button Click Handling
        private void AddSubjectBtn_OnClick(object sender, RoutedEventArgs e)
        {
            WindowManager.OpenAddSubjectWindow();
        }
        private void RemoveSubjectBtn_OnClick(object sender, RoutedEventArgs e)
        {
            
        }
        private void EditSubjectBtn_OnClick(object sender, RoutedEventArgs e)
        {
            
        }
        private void ConfirmBtn_OnClick(object sender, RoutedEventArgs e)
        {
            SessionManager.UpdateWeeklySchedule(Schedule);
        }
        private void CloseBtn_OnClick(object sender, RoutedEventArgs e)
        {
            WindowManager.CloseTrackedWindow(this);
        }
        
        
        // window closed state
        private void ProfessorSubjectManagerWindow_OnClosed(object sender, EventArgs e)
        {
            WindowManager.UnTrackWindow(this);
        }
    }
}
