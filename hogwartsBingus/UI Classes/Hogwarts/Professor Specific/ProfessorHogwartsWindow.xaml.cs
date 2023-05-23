using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using hogwartsBingus.DataStorage;
using hogwartsBingus.Session;
using hogwartsBingus.University.Excercies;
using hogwartsBingus.University.StudySessionRelactedClasses;

namespace hogwartsBingus.UI_Classes.Hogwarts.Professor_Specific
{
    /// <summary>
    /// Interaction logic for ProfessorHogwartsWindow.xaml
    /// </summary>
    public partial class ProfessorHogwartsWindow
    {
        public ProfessorHogwartsWindow()
        {
            InitializeComponent();
            UpdateSubjectsList();
        }
        
        // Date/Time label content update
        private void UpdateTimeTrayLabels()
        {
            DateTime time = GlobalClock.CurrentTime;
            
            DayNameLabel.Content = time.DayOfWeek.ToString();
            DateLabel.Content = $"{time.Year:D2}/{time.Month:D2}/{time.Day:D2}";
            TimeLabel.Content = $"{time.Hour:D2}:{time.Minute:D2}";
        }

        
        // label content updates
        private void UpdateExerciseDescription()
        {
            string[] description = SubjectManager.FindSubjectByName(SubjectsList.SelectedItem.ToString())
                .GetExerciseWithName(ExercisesList.SelectedItem.ToString()).GetExerciseOverview();

            ExerciseDescriptionLabel.Content = $"{description[0]}\n\n{description[1]}";
        }
        
        
        // List Updates
        private void UpdateSubjectsList()
        {
            SubjectsList.ItemsSource = GenerateSubjectTitles();
        }

        private void UpdateExerciseList()
        {
            ExercisesList.UnselectAll();
            ExercisesList.ItemsSource = GenerateExerciseTitles();
        }
        
        
        //Generate List Titles
        private string[] GenerateSubjectTitles()
        {
            List<StudySubject> subjects = SessionManager.GetWeeklySchedule().Subjects;

            if (subjects == null) return null;
            
            string[] titles = new string[subjects.Count];
            
            for (int i = 0; i < titles.Length; i++)
            {
                titles[i] = $"{subjects[i].Name}";
            }

            return titles;

        }
        private string[] GenerateExerciseTitles()
        {
            List<Exercise> exercises = SubjectManager.FindSubjectByName(SubjectsList.SelectedItem.ToString()).Exercises;

            if (exercises?.Count == 0) return null;

            List<string> titles = new List<string>();

            if (exercises != null)
                foreach (var uncheckedExercise in exercises)
                {
                    titles.Add(uncheckedExercise.Name);
                }

            return titles.ToArray();
        }


        // Button click handlers
        private void BackBtn_OnClick(object sender, RoutedEventArgs e)
        {
            WindowManager.LaunchLandingPage();
        }

        
        // List box item change handlers
        private void SubjectsList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SubjectsList.SelectedItem == null)
            {
                AddExerciseBtn.IsEnabled = false;
                return;
            }

            AddExerciseBtn.IsEnabled = true;
            UpdateExerciseList();
        }

        private void ExercisesList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ExercisesList.SelectedItem == null)
            {
                RemoveExerciseBtn.IsEnabled = false;
                EditExerciseBtn.IsEnabled = false;
                return;
            }

            RemoveExerciseBtn.IsEnabled = true;
            EditExerciseBtn.IsEnabled = true;
            UpdateExerciseDescription();
        }

        private void AddExerciseBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (SubjectsList.SelectedItem == null) return;
            WindowManager.OpenExerciseAddWindow(SubjectsList.SelectedItem.ToString());
        }

        private void ProfessorHogwartsWindow_OnMouseEnter(object sender, MouseEventArgs e)
        {
            ExercisesList.UnselectAll();
            SubjectsList.UnselectAll();
            ExercisesList.ItemsSource = null;
        }

        private void RemoveExerciseBtn_OnClick(object sender, RoutedEventArgs e)
        {
            SubjectManager.FindSubjectByName(SubjectsList.SelectedItem.ToString())
                .RemoveExerciseByName(ExercisesList.SelectedItem.ToString());
            UpdateExerciseList();
            ExerciseDescriptionLabel.Content = "";
        }

        private void EditExerciseBtn_OnClick(object sender, RoutedEventArgs e)
        {
            WindowManager.OpenExerciseEditWindow(SubjectsList.SelectedItem.ToString(), 
                ExercisesList.SelectedItem.ToString());
        }
    }
}
