using System.Windows;
using hogwartsBingus.DataStorage;
using hogwartsBingus.University.DormitoryData;

namespace hogwartsBingus.UI_Classes
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            PlantManager.PopulateWorld();
        }
    }
}