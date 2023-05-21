using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using hogwartsBingus.Base_Classes;
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
        
        // Update List Content
        private void UpdateSessionList()
        {
            SessionList.ItemsSource = GenerateSessionListContent();
        }
        
        
        // Generate List Content
        private string[] GenerateSessionListContent()
        {
            List<string> titles = new List<string>();
            
            Subject.Sessions.ForEach(time => titles.Add($"{time.StartTime.Hours}:{time.StartTime.Minutes}" +
                                                        $"→" +
                                                        $"{time.StartTime.Hours + time.Duration.Hours}:" +
                                                        $"{time.StartTime.Minutes + time.Duration.Minutes}"));

            return titles.ToArray();
        }
        
        
        // Fill Combo box
        private void FillDayOfWeekComboBox()
        {
            string[] days = new string[5];
            
            for (int i = 2; i < 7; i++)
            {
                days[i - 2] = Enum.GetName(typeof(DayOfWeek), i);
            }

            DayOfWeekComboBox.ItemsSource = days;
        }
    }
}
