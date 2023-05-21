using System.Windows;
using hogwartsBingus.Session;
using hogwartsBingus.University.DormitoryData;

namespace hogwartsBingus.UI_Classes.Ceremony
{
    /// <summary>
    /// Interaction logic for BedAssignmentWindow.xaml
    /// </summary>
    public partial class BedAssignmentWindow : Window
    {
        public BedAssignmentWindow()
        {
            InitializeComponent();
        }
        private void BedAssignBtn_OnClick(object sender, RoutedEventArgs e)
        {
            int bedNumber = DormitoryManager.GetBedNumberOfType(SessionManager.GetUserFaction().Value);
            
            SessionManager.RequestSetBedNumber(bedNumber);
            
            BedNumLabel.Content = bedNumber.ToString();

            BedAssignBtn.IsEnabled = false;
        }
    }
}
