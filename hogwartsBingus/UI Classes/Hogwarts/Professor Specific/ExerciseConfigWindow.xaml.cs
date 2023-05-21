using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.DataStorage;
using hogwartsBingus.Session;
using hogwartsBingus.University.Excercies;

namespace hogwartsBingus.UI_Classes.Hogwarts.Professor_Specific
{
    /// <summary>
    /// Interaction logic for ExerciseConfigWindow.xaml
    /// </summary>
    public partial class ExerciseConfigWindow : Window
    {
        private string SubjectName;
        private Exercise Exercise;
        private WindowEditMode EditMode;

        private Regex YearFormat = new Regex(@"^\d{4}$"),
            MonthFormat = new Regex(@"(^0?[0-9]$)|(^1[0-2]$)"),
            DayFormat = new Regex(@"(^[0-2]?[0-9]$)|(^3[0-1]$)");
        public ExerciseConfigWindow(string subjectName)
        {
            InitializeComponent();
            SubjectName = subjectName;
            EditMode = WindowEditMode.AddMode;
        }
        
        public ExerciseConfigWindow(string subjectName, string exerciseName)
        {
            InitializeComponent();
            Exercise = SubjectManager.GetSubjectByName(subjectName).GetExerciseWithName(exerciseName);
            SubjectName = subjectName;
            EditMode = WindowEditMode.EditMode;
            SetFieldValues();
        }

        private void SetFieldValues()
        {
            ExerciseTitleField.Text = Exercise.Name;
            ExerciseDescField.Text = Exercise.Description;

            DateTime deadLine = Exercise.DeadLine;
            
            YearField.Text = deadLine.Year.ToString();
            MonthField.Text = deadLine.Month.ToString();
            DayField.Text = deadLine.Day.ToString();
        }

        private Exercise GenerateExercise()
        {
            string
                title = ExerciseTitleField.Text,
                description = ExerciseDescField.Text,
                deadLineString = $"{YearField.Text}/{MonthField.Text}/{DayField.Text}";

            if (title == "" || description == "" || !YearFormat.IsMatch(YearField.Text) ||
                !MonthFormat.IsMatch(MonthField.Text) || !DayFormat.IsMatch(DayField.Text)) return null;

            if (!DateTime.TryParse(deadLineString, out var deadLine)) return null;

            return new Exercise(title, description, deadLine);
        }

        private void ConfirmBtn_OnClick(object sender, RoutedEventArgs e)
        {
            Exercise newExercise = GenerateExercise();
            if (newExercise == null) return;
            switch (EditMode)
            {
                case WindowEditMode.EditMode :
                    SubjectManager.GetSubjectByName(SubjectName).EditExercise(Exercise, newExercise);
                    break;
                case WindowEditMode.AddMode :
                    SubjectManager.GetSubjectByName(SubjectName).AddExercise(newExercise);
                    break;
            }
            WindowManager.CloseTrackedWindow(this);
        }

        private void YearField_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (YearFormat.IsMatch(YearField.Text))
            {
                YearField.Foreground = DraculaThemeColors.GreenBrush;
                return;
            }
            YearField.Foreground = DraculaThemeColors.RedBrush;
        }

        private void MonthField_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (MonthFormat.IsMatch(MonthField.Text))
            {
                MonthField.Foreground = DraculaThemeColors.GreenBrush;
                return;
            }
            MonthField.Foreground = DraculaThemeColors.RedBrush;
        }

        private void DayField_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (DayFormat.IsMatch(DayField.Text))
            {
                DayField.Foreground = DraculaThemeColors.GreenBrush;
                return;
            }
            DayField.Foreground = DraculaThemeColors.RedBrush;
        }

        private void ExerciseConfigWindow_OnClosed(object sender, EventArgs e)
        {
            WindowManager.UnTrackWindow(this);
        }

        private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            WindowManager.CloseTrackedWindow(this);
        }
    }
}
