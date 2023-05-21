using System;
using System.Windows;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.Execptions;
using hogwartsBingus.Factions;
using hogwartsBingus.Session;
using hogwartsBingus.University.DormitoryData;

namespace hogwartsBingus.UI_Classes.Ceremony
{
    /// <summary>
    /// Interaction logic for FactionAssignmentWindow.xaml
    /// </summary>
    public partial class FactionAssignmentWindow : Window
    {
        private Random random = new Random();
        
        public FactionAssignmentWindow()
        {
            InitializeComponent();
        }

        private void AssignBtn_Click(object sender, RoutedEventArgs e)
        {
            AssignFaction();
        }

        private void AssignFaction()
        {
            FactionType chosenFaction = FactionManager.GetRandomFaction();
            try
            {
                SessionManager.RequestSetFaction(chosenFaction);
            }
            catch (StudentAlreadyHasFactionException e)
            {
                Console.WriteLine(e);
                //add error handling here later
            }

            AssignBtn.IsEnabled = false;
            UpdateAssignedFactionLabelText(chosenFaction.ToString());
        }

        private void UpdateAssignedFactionLabelText(string factionName)
        {
            FactionNameDisplayLabel.Content = factionName;
        }
    }
}
