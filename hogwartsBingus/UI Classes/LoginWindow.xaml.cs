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

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}