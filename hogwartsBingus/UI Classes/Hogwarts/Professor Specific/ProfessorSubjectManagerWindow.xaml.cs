using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
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
            UpdateSubjectsList();
            UpdateWeeklyScheduleDisplay();
            SubjectManager.SubjectsChanged += UpdateSchedule;
        }
        
        private void UpdateSchedule()
        {
            Schedule = SessionManager.GetWeeklySchedule();
            
            UpdateSubjectsList();
            UpdateWeeklyScheduleDisplay();
        }
        
        
        // Update Subjects List
        private void UpdateSubjectsList()
        {
            SubjectsList.ItemsSource = GenerateSubjectListContent();
        }
        private string[] GenerateSubjectListContent()
        {
            List<string> titles = new List<string>();

            if (Schedule.Subjects.Count == 0) return titles.ToArray();

            foreach (var subject in Schedule.Subjects)
            {
                titles.Add(subject.ToString());
            }

            return titles.ToArray();
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
            int y = time.Days;
            return x + y * 11;
        }
        
        
        // Button Click Handling
        private void AddSubjectBtn_OnClick(object sender, RoutedEventArgs e)
        {
            WindowManager.OpenProfessorAddSubjectWindow(SessionManager.GetUserFullName());
        }
        private void RemoveSubjectBtn_OnClick(object sender, RoutedEventArgs e)
        {
            Schedule.RemoveSubject(SubjectManager.FindSubjectByName(SubjectsList.SelectedItem.ToString()));
            SubjectManager.RemoveStudySubject(SubjectManager.FindSubjectByName(SubjectsList.SelectedItem.ToString()));
            
            UpdateSubjectsList();
        }
        private void EditSubjectBtn_OnClick(object sender, RoutedEventArgs e)
        {
            WindowManager.OpenProfessorEditSubjectWindow(
                SubjectManager.FindSubjectByName(SubjectsList.SelectedItem.ToString()));
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
        
        
        // list selection changed
        private void SubjectsList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SubjectsList.SelectedItem == null)
            {
                EditSubjectBtn.IsEnabled = false;
                RemoveSubjectBtn.IsEnabled = false;
                return;
            }
            
            EditSubjectBtn.IsEnabled = true;
            RemoveSubjectBtn.IsEnabled = true;
        }
    }
}
