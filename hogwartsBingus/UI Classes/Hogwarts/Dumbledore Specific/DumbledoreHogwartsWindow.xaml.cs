using System.Collections.Generic;
using System.Windows;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.DataStorage;
using hogwartsBingus.University.DormitoryData;

namespace hogwartsBingus.UI_Classes.Hogwarts.Dumbledore_Specific
{
    /// <summary>
    /// Interaction logic for DumbledoreHogwartsWindow.xaml
    /// </summary>
    public partial class DumbledoreHogwartsWindow : Window
    {
        public DumbledoreHogwartsWindow()
        {
            InitializeComponent();
            UpdatePageContent();
        }

        
        // page content update
        private void UpdatePageContent()
        {
            UpdateDormitoryList();
            UpdateSubjectsList();
            UpdateUsersList();
            UpdateTicketRequestsList();
        }

        // Update List items
        private void UpdateDormitoryList()
        {
            DormitoriesList.ItemsSource = GenerateDormitoriesTitles();
        }
        private void UpdateUsersList()
        {
            UsersList.ItemsSource = GenerateUsersTitles();
        }
        private void UpdateSubjectsList()
        {
            SubjectsList.ItemsSource = GenerateStudySubjectTitles();
        }
        private void UpdateTicketRequestsList()
        {
            TicketRequestsList.ItemsSource = GenerateTicketRequestTitles();
        }

        // generating List content
        private string[] GenerateTicketRequestTitles()
        {
            List<string> titles = new List<string>();

            foreach (var request in TicketRequestHandler.TicketRequests)
            {
                titles.Add(request.ToString());
            }

            return titles.ToArray();
        }
        private string[] GenerateDormitoriesTitles()
        {
            List<string> titles = new List<string>();

            foreach (var dormitory in DormitoryManager.Dormitories)
            {
                titles.Add(dormitory.ToString());
            }

            return titles.ToArray();
        }
        private string[] GenerateStudySubjectTitles()
        {
            List<string> titles = new List<string>();

            foreach (var subject in SubjectManager.GetAllSubjects())
            {
                titles.Add(subject.ToString());
            }

            return titles.ToArray();
        }
        private string[] GenerateUsersTitles()
        {
            List<string> titles = new List<string>();

            foreach (var user in UserManager.Users)
            {
                if (user.AuthType == AuthorizationType.Dumbledore) continue;
                titles.Add(user.ToString());
            }

            return titles.ToArray();
        }
        
        // update faction stats labels
        private void UpdateFactionStatsLabels()
        {
            
        }
    }
}
