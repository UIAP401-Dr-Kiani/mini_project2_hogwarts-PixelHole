using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using hogwartsBingus.DataStorage;
using hogwartsBingus.Session;
using hogwartsBingus.University.Excercies;
using hogwartsBingus.University.StudySessionRelactedClasses;

namespace hogwartsBingus.UI_Classes.Hogwarts.Student_Specific
{
    /// <summary>
    /// Interaction logic for StudentHogwartsWindow.xaml
    /// </summary>
    public partial class StudentHogwartsWindow : Window
    {
        private StudySubject subject;
        private Exercise exercise;
        public StudentHogwartsWindow()
        {
            InitializeComponent();
            UpdateSubjectsList();
            UpdateTimeLabels();
        }

        
        //update Selected Items
        private void UpdateSelectedSubject()
        {
            if (SubjectsList.SelectedIndex == -1) return;
            subject = SubjectManager.GetSubjectByName(SubjectsList.SelectedItem.ToString());
        }
        private void UpdateSelectedExercise()
        {
            if (ExerciseList.SelectedIndex == -1) return;
            exercise = subject.GetExerciseWithName(ExerciseList.SelectedItem.ToString());
        }
        
        
        // Update window content
        private void UpdateSubjectsList()
        {
            SubjectsList.ItemsSource = GenerateSubjectTitles();
        }
        private void UpdateExerciseList()
        {
            ExerciseList.UnselectAll();
            ExerciseList.ItemsSource = GenerateExercisesTitles();
        }
        private void UpdateSubjectDescription()
        {
            if (subject == null) return;
            SubjectInfoLabel.Content = $"{subject.Name}\n\nTeaching Professor : Prf. {subject.Professor.LastName}\n\n" +
                                       $"Students in class : {subject.StudentCount}";
        }
        private void UpdateExerciseDescription()
        {
            if (ExerciseList.SelectedIndex == -1) return;
            string[] description = exercise.GetExerciseOverview();
            ExerciseDescLabel.Content = $"{description[0]}\n\n{description[1]}";
        }
        private void UpdateTimeLabels()
        {
            DateTime time = GlobalClock.CurrentTime;
            TimeLabel.Content = time.TimeOfDay;
            DayNameLabel.Content = time.DayOfWeek;
            DateLabel.Content = $"{time.Year}/{time.Month:D2}/{time.Day:D2}";
        }


        //utility
        private void ClearExerciseDescription()
        {
            ExerciseDescLabel.Content = "";
        }

        private void ClearSubjectDescription()
        {
            SubjectInfoLabel.Content = "";
        }

        
        // title generators for List boxes
        private string[] GenerateExercisesTitles()
        {
            List<Exercise> exercises = SessionManager.GetWeeklySchedule()?.Subjects[SubjectsList.SelectedIndex].Exercises;

            if (exercises?.Count == 0) return null;

            List<string> titles = new List<string>();

            foreach (var uncheckedExercise in exercises)
            {
                if (uncheckedExercise.StudentHasDoneExercise(SessionManager.GetUserID())) continue;
                titles.Add(uncheckedExercise.Name);
            }

            return titles.ToArray();
        }
        private string[] GenerateSubjectTitles()
        {
            List<StudySubject> subjects = SessionManager.GetWeeklySchedule()?.Subjects;

            if (subjects == null) return null;

            string[] titles = new string[subjects.Count];
            
            for (int i = 0; i < titles.Length; i++)
            {
                titles[i] = $"{subjects[i].Name}";
            }

            return titles;
        }

        
        // Listbox item change handlers
        private void SubjectsList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSelectedSubject();
            ClearSubjectDescription();
            ClearExerciseDescription();
            UpdateExerciseList();
            UpdateSubjectDescription();
        }
        private void ExerciseList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSelectedExercise();
            UpdateExerciseDescription();
        }
        
        
        // button click handlers
        private void ShowScheduleBtn_OnClick(object sender, RoutedEventArgs e)
        {
            WindowManager.OpenWeeklyScheduleWindow();
        }
        private void BackBtn_OnClick(object sender, RoutedEventArgs e)
        {
            WindowManager.LaunchLandingPageOfType(SessionManager.GetUserType());
        }

        private void DoExerciseBtn_OnClick(object sender, RoutedEventArgs e)
        {
            exercise.StudentFinishedExercise(SessionManager.GetUserID());
            ClearExerciseDescription();
            UpdateExerciseList();
            exercise = null;
        }
    }
}
