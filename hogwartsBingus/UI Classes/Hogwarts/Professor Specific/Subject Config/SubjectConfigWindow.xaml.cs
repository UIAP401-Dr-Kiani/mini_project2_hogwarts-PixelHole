using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.DataStorage;
using hogwartsBingus.Session;
using hogwartsBingus.University.StudySessionRelactedClasses;

namespace hogwartsBingus.UI_Classes.Hogwarts.Professor_Specific.Subject_Config
{
    /// <summary>
    /// Interaction logic for SubjectConfigWindow.xaml
    /// </summary>
    public partial class SubjectConfigWindow : Window
    {
        private WindowEditMode EditMode = WindowEditMode.AddMode;

        private Regex TimeFormat = new Regex(@"([01][01]?[0-9]|2[0-3]):[0-5][0-9]"),
            SemesterFormat = new Regex(@"\d[1-8]"),
            DurationFormat = new Regex(@"2|1");

        private StudySubject Subject = new StudySubject();
        
        public SubjectConfigWindow()
        {
            InitializeComponent();
            FillDayOfWeekComboBox();
            UpdateSessionList();
        }

        public SubjectConfigWindow(StudySubject subject) : this()
        {
            EditMode = WindowEditMode.EditMode;
            Subject = subject;
        }
        
        
        // Update session table
        private void UpdateSessionTimeTable()
        {
            string[] table = new string[50];

            for (int i = 0; i < 50; i++)
            {
                table[i] = "-";
            }
            
            
            if (Subject.Sessions == null)
            {
                SessionTimeTable.ItemsSource = table;
                return;
            }

            foreach (var session in Subject.Sessions)
            {
                for (int i = 0; i < session.Duration.Hours; i++)
                {
                    table[TimeSpanToIndex(session.StartTime.Add(new TimeSpan(0, i, 0, 0)))] = "+";
                }
            }

            SessionTimeTable.ItemsSource = table;
        }
        private int TimeSpanToIndex(TimeSpan time)
        {
            int y = time.Days - 1,
                x = time.Hours - 8;

            return y * 10 + x;
        }


        // Update List Content
        private void UpdateSessionList()
        {
            SessionList.ItemsSource = GenerateSessionListContent();
            UpdateSessionTimeTable();
        }
        
        
        // Generate List Content
        private string[] GenerateSessionListContent()
        {
            List<string> titles = new List<string>();

            if (Subject.Sessions == null) return titles.ToArray();
            
            Subject.Sessions.ForEach(time => titles.Add(time.ToString()));

            return titles.ToArray();
        }
        
        
        // Fill Combo box
        private void FillDayOfWeekComboBox()
        {
            string[] days = new string[5];
            
            for (int i = 1; i < 6; i++)
            {
                days[i - 1] = Enum.GetName(typeof(DayOfWeek), i);
            }

            DayOfWeekComboBox.ItemsSource = days;
        }
        
        
        // utility
        private void ClearAddSessionFields()
        {
            HourOfDayField.Text = "";
            DurationField.Text = "";
            DayOfWeekComboBox.SelectedItem = null;
        }
        private bool AddSessionFieldsHaveCorrectValue()
        {
            return HourOfDayField.Text != "" && DurationField.Text != "" && TimeFormat.IsMatch(HourOfDayField.Text) &&
                   DurationFormat.IsMatch(DurationField.Text) && DayOfWeekComboBox.SelectedItem != null;
        }
        private bool SubjectDescriptionFieldsHaveCorrectValue()
        {
            return TitleField.Text != "" && SemesterFormat.IsMatch(SemesterField.Text) &&
                   int.TryParse(CapacityField.Text, out _) && CapacityField.Text != "";
        }


        // button click handling
        private void ClearBtn_OnClick(object sender, RoutedEventArgs e)
        {
            ClearAddSessionFields();
        }
        private void AddBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (AddSessionFieldsHaveCorrectValue())
            {
                TimeSpan startTime = new TimeSpan(DayOfWeekComboBox.SelectedIndex + 1,
                        int.Parse(HourOfDayField.Text.Split(':')[0]),
                        int.Parse(HourOfDayField.Text.Split(':')[1]),
                        0),
                    duration = new TimeSpan(0, int.Parse(DurationField.Text), 0, 0);
                
                Subject.AddSession(new StudySessionTime(startTime, duration));
                
                UpdateSessionList();
                ClearAddSessionFields();
            }
        }
        private void RemoveBtn_OnClick(object sender, RoutedEventArgs e)
        {
            Subject.RemoveSession(Subject.FindSessionWithString(SessionList.SelectedItem.ToString()));
            UpdateSessionList();
        }
        
        
        // window close state
        private void SubjectConfigWindow_OnClosed(object sender, EventArgs e)
        {
            WindowManager.UnTrackWindow(this);
        }
        
        
        // TextBox text changed handling
        private void HourOfDayField_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (TimeFormat.IsMatch(HourOfDayField.Text))
            {
                HourOfDayField.Foreground = DraculaThemeColors.GreenBrush;
                return;
            }

            HourOfDayField.Foreground = DraculaThemeColors.RedBrush;
        }
        private void DurationField_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (DurationFormat.IsMatch(DurationField.Text))
            {
                DurationField.Foreground = DraculaThemeColors.GreenBrush;
                return;
            }

            DurationField.Foreground = DraculaThemeColors.RedBrush;
        }
    }
}
