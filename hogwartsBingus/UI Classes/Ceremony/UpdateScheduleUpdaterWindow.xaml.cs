using hogwartsBingus.Session;
using System;
using System.Collections.Generic;
using System.Management.Instrumentation;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.DataStorage;
using hogwartsBingus.Execptions;
using hogwartsBingus.University.StudySessionRelactedClasses;

namespace hogwartsBingus.UI_Classes.Ceremony
{
    /// <summary>
    /// Interaction logic for WeeklyScheduleUpdaterWindow.xaml
    /// </summary>
    public partial class UpdateScheduleUpdaterWindow
    {
        private WeeklySchedule Schedule = new WeeklySchedule();
        private List<StudySubject> Subjects = new List<StudySubject>();

        private bool CheckForIntersection = true;
        public UpdateScheduleUpdaterWindow()
        {
            InitializeComponent();
            UpdateIntersectionCheckBool();
            GetScheduleFromUser();
            GetStudySubjects();
            UpdateWindowContent();
        }

        
        private void UpdateIntersectionCheckBool()
        {
            bool? intersectionCheck = SessionManager.GetCanTeachAtMultipleLocations();
            if (intersectionCheck == null) return;

            CheckForIntersection = !intersectionCheck.Value;
        }
        private void UpdateWindowContent()
        {
            UpdatePickedSubjectsList();
            UpdateAvailableSubjectsList();
            UpdateWeeklyScheduleDisplay();
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
                        content[index + i] += $"{subject.Name}\n";
                    }
                }
            }

            return content;
        }

        private void GetScheduleFromUser()
        {
            WeeklySchedule userSchedule = SessionManager.GetWeeklySchedule() == null
                ? new WeeklySchedule()
                : SessionManager.GetWeeklySchedule();

            foreach (var subject in userSchedule.Subjects)
            {
                Schedule.AddSubject(subject, CheckForIntersection);
            }
        }

        private void GetStudySubjects()
        {
            Subjects = SubjectManager.GetAllSubjects();
        }

        private int TimeSpanToDisplayTableIndex(TimeSpan time)
        {
            int x = time.Hours - 7;
            int y = time.Days - 2;
            return x + y * 11;
        }

        private void UpdateAvailableSubjectsList()
        {
            List<StudySubject> unpicked = new List<StudySubject>();
            unpicked.AddRange(Subjects);

            foreach (var subject in Schedule.Subjects)
            {
                unpicked.Remove(subject);
            }

            AvailableSubjectsList.ItemsSource = GenerateTitlesList(unpicked);
        }
        private void UpdatePickedSubjectsList()
        {
            PickedSubjectsList.ItemsSource = GenerateTitlesList(Schedule.Subjects);
        }
        private List<string> GenerateTitlesList(List<StudySubject> subjects)
        {
            List<string> titles = new List<string>();
            
            foreach (var subject in subjects)
            {
                StringBuilder Title = new StringBuilder(subject.Name + "\n\n");

                foreach (var session in subject.Sessions)
                {
                    Title.Append(Enum.GetName(typeof(Day), session.StartTime.Days - 1) + " ");
                    Title.Append($"{session.StartTime.Hours:D2}:{session.StartTime.Minutes:D2} → " +
                                 $"{session.StartTime.Hours + session.Duration.Hours:D2}:" +
                                 $"{session.StartTime.Minutes + session.Duration.Minutes:D2}\n");
                }
                
                titles.Add(Title.ToString());
            }

            return titles;
        }

        private string GetSubjectTitleFromList(ListBox list, int index)
        {
            return list.SelectedItem.ToString().Split('\n')[0];
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            WindowManager.UnTrackWindow(this);
        }
        
        
        // button click event handlers
        private void PickBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (!AvailableSubjectsList.HasItems || AvailableSubjectsList.SelectedItem == null) return;
            
            ClearLogContent();
            try
            {
                Schedule.AddSubject(SubjectManager.GetSubjectByName(GetSubjectTitleFromList(AvailableSubjectsList,
                    AvailableSubjectsList.SelectedIndex)), CheckForIntersection);
            }
            catch (StudySessionIntersectionException)
            {
                LogLabel.Content = "This Subject intersects with another subject that you have picked";
            }
            catch (InstanceNotFoundException instanceNotFoundException)
            {
                Console.WriteLine(instanceNotFoundException);
                throw;
            }
            UpdateWindowContent();
        }
        private void RemoveBtn_OnClick(object sender, RoutedEventArgs e)
        {
            ClearLogContent();
            if (!PickedSubjectsList.HasItems || PickedSubjectsList.SelectedItem == null) return;
            try
            {
                Schedule.RemoveSubject(SubjectManager.GetSubjectByName(GetSubjectTitleFromList(PickedSubjectsList,
                    PickedSubjectsList.SelectedIndex)));
            }
            catch (InstanceNotFoundException exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            UpdateWindowContent();
        }
        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            SessionManager.UpdateWeeklySchedule(Schedule);
            LogLabel.Content = "Weekly Schedule Updated!";
        }
        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.CloseTrackedWindow(this);
        }
        
        
        //utility
        private void ClearLogContent()
        {
            LogLabel.Content = "";
        }
    }
}