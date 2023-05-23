using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.DataStorage;
using hogwartsBingus.Factions;
using hogwartsBingus.Session;
using hogwartsBingus.University.DormitoryData;
using hogwartsBingus.University.StudySessionRelactedClasses;

namespace hogwartsBingus.UI_Classes.Hogwarts.Dumbledore_Specific
{
    /// <summary>
    /// Interaction logic for DumbledoreHogwartsWindow.xaml
    /// </summary>
    public partial class DumbledoreHogwartsWindow
    {
        public DumbledoreHogwartsWindow()
        {
            InitializeComponent();
            UpdatePageContent();
        }


        // page content update
        private void UpdatePageContent()
        {
            UpdateClockRibbonLabels();
            UpdateDormitoryList();
            UpdateSubjectsList();
            UpdateUsersList();
            UpdateTicketRequestsList();
            UpdateFactionStatsLabels();
        }

        // Update Clock Ribbon
        private void UpdateClockRibbonLabels()
        {
            DayNameLabel.Content = GlobalClock.CurrentTime.DayOfWeek.ToString();
            HourLabel.Content = GlobalClock.CurrentTime.TimeOfDay;

            int[] date = GlobalClock.GetFullDate();

            FullDateLabel.Content = $"{date[0]}/{date[1]}/{date[2]}";
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
            GryffindorStatsLabel.Content = GenerateFactionStats(FactionType.Gryffindor);
            SlytherinStatsLabel.Content = GenerateFactionStats(FactionType.Slytherin);
            HufflepuffStatsLabel.Content = GenerateFactionStats(FactionType.Hufflepuff);
            RavenclawStatsLabel.Content = GenerateFactionStats(FactionType.Raveclaw);
        }
        private string GenerateFactionStats(FactionType faction)
        {
            StringBuilder statText = new StringBuilder();

            statText.Append($"Points : {FactionManager.GetFactionPoints(faction)}");
            statText.Append($"\nMembers : {FactionManager.GetFactionMemberCount(faction)}");

            return statText.ToString();
        }


        // Update List Description Labels
        private void UpdateDormitoryDescLabelContent()
        {
            if (DormitoriesList.SelectedItem == null) return;
            
            Dormitory dormitory = DormitoryManager.GetDormitoryByName(DormitoriesList.SelectedItem.ToString());
            
            DormitoryStatsLabel.Content = $"{dormitory.Name}\n{dormitory.Faction.ToString()}\n\n" +
                                          $"Capacity : {dormitory.Capacity}\n\nResident Count : {dormitory.ResidentsCount}";
        }
        private void UpdateUserDescLabelContent()
        {
            if (UsersList.SelectedItem == null) return;

            int userIndex = UserManager.FindWithName(UsersList.SelectedItem.ToString());
            
            string[] userInfo = UserManager.GetGeneralUserInfoAt(userIndex);
            
            StringBuilder finalText = new StringBuilder();

            finalText.Append($"{userInfo[0]}\n{userInfo[2]}\n\nBorn : {userInfo[1]}\n\n" +
                             $"{userInfo[3].Replace('_', ' ')}");
            
            if (userInfo[4] != null)
            {
                finalText.Append($"\n\nFather : {userInfo[4]}");
            }

            finalText.Append($"\n\nID : {userInfo[5]}\n\nAssigned Pet : {userInfo[6]}\n\n");

            switch (UserManager.GetAuthTypeAt(userIndex))
            {
                case AuthorizationType.Student :
                    finalText.Append($"{userInfo[9]}\n\nHouse : {userInfo[7]}\n\nDormitory Number : ");
                    
                    if (userInfo[8] != "0")
                    {
                        finalText.Append(userInfo[8]);
                        break;
                    }

                    finalText.Append("Not Assigned");
                    break;
                case AuthorizationType.Professor :
                    finalText.Append($"{userInfo[8]}\n\nCan Teach At multiple locations : {userInfo[7]}\n");
                    break;
                case AuthorizationType.Dumbledore :
                    finalText.Append("System Admin");
                    break;
            }

            UserDescriptionLabel.Content = finalText.ToString();
        }

        // Window CLose / active handling
        private void DumbledoreHogwartsWindow_OnClosed(object sender, EventArgs e)
        {
            WindowManager.UnTrackWindow(this);
        }
        private void DumbledoreHogwartsWindow_OnActivated(object sender, EventArgs e)
        {
            UpdatePageContent();
            CheckListsForItemSelection();
        }


        // Button Click Handling
        private void BackBtn_OnClick(object sender, RoutedEventArgs e)
        {
            WindowManager.LaunchLandingPage();
        }
        private void RemoveDormitoryBtn_OnClick(object sender, RoutedEventArgs e)
        {
            Dormitory dormitory = DormitoryManager.GetDormitoryByName(DormitoriesList.SelectedItem.ToString());
            if (dormitory.ResidentsCount > 0) return;
            
            DormitoryManager.RemoveDormitory(dormitory);
        }
        private void TicketRequestGrantBtn_OnClick(object sender, RoutedEventArgs e)
        {
            TicketRequestHandler.GrantTicketRequest(
                TicketRequestHandler.FindRequest(TicketRequestsList.SelectedItem.ToString()));
            UpdateTicketRequestsList();
        }
        private void TicketRequestDenyBtn_OnClick(object sender, RoutedEventArgs e)
        {
            TicketRequestHandler.RemoveTicketRequest(
                TicketRequestHandler.FindRequest(TicketRequestsList.SelectedItem.ToString()));
            UpdateTicketRequestsList();
        }
        private void RemoveUserBtn_OnClick(object sender, RoutedEventArgs e)
        {
            UserManager.RemoveUser(
                UserManager.GetUserAtIndex(UserManager.FindWithName(UsersList.SelectedItem.ToString())));
            UpdateUsersList();
        }
        private void RemoveSubjectBtn_OnClick(object sender, RoutedEventArgs e)
        {
            StudySubject subject = SubjectManager.FindSubjectByName(SubjectsList.SelectedItem.ToString());
            
            UserManager.RemoveSubjectFromUsers(subject);
            
            SubjectManager.RemoveStudySubject(subject);
            
            UpdateSubjectsList();
        }
        private void TicketRequestCreateBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.OpenRequestTicketWindow();
        }
        private void MessageUserBtn_OnClick(object sender, RoutedEventArgs e)
        {
            WindowManager.OpenComposeMessageWindow(UsersList.SelectedItem.ToString());
        }
        private void AddDormitoryBtn_OnClick(object sender, RoutedEventArgs e)
        {
            WindowManager.OpenAddDormitoryWindow();
        }
        private void AddSubjectBtn_OnClick(object sender, RoutedEventArgs e)
        {
            WindowManager.OpenAddSubjectWindow();
        }
        

        // Button Activation Handling
        private void SwitchDormitoryRemoveBtn(bool state)
        {
            RemoveDormitoryBtn.IsEnabled = state;
        }
        private void SwitchUserListButtons(bool state)
        {
            RemoveUserBtn.IsEnabled = state;
            EditUserBtn.IsEnabled = state;
            MessageUserBtn.IsEnabled = state;
        }
        private void SwitchSubjectListButtons(bool state)
        {
            RemoveSubjectBtn.IsEnabled = state;
            EditSubjectBtn.IsEnabled = state;
            ShowSubjectInfoBtn.IsEnabled = state;
        }
        private void SwitchTicketRequestListButtons(bool state)
        {
            TicketRequestGrantBtn.IsEnabled = state;
            TicketRequestDenyBtn.IsEnabled = state;
        }


        // List Selected Item Changed Handling
        private void CheckListsForItemSelection()
        {
            SwitchDormitoryRemoveBtn(DormitoriesList.SelectedItem != null);
            SwitchSubjectListButtons(SubjectsList.SelectedItem != null);
            SwitchUserListButtons(UsersList.SelectedItem != null);
            SwitchTicketRequestListButtons(TicketRequestsList.SelectedItem != null);
        }
        private void DormitoriesList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SwitchDormitoryRemoveBtn(DormitoriesList.SelectedItem != null);
            UpdateDormitoryDescLabelContent();
        }
        private void UsersList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SwitchUserListButtons(UsersList.SelectedItem != null);
            UpdateUserDescLabelContent();
        }
        private void SubjectsList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SwitchSubjectListButtons(SubjectsList.SelectedItem != null);
        }
        private void TicketRequestsList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SwitchTicketRequestListButtons(TicketRequestsList.SelectedItem != null);
        }
    }
}
