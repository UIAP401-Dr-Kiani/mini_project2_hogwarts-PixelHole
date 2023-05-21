using System;
using System.Windows;
using System.Windows.Controls;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.DataStorage;
using hogwartsBingus.Execptions;
using hogwartsBingus.Session;
using hogwartsBingus.University.DormitoryData;

namespace hogwartsBingus.UI_Classes.Hogwarts.Dumbledore_Specific
{
    /// <summary>
    /// Interaction logic for DormitoryConfigWindow.xaml
    /// </summary>
    public partial class DormitoryConfigWindow : Window
    {
        private string DormitoryName;
        private int DormitoryFloorCount;
        private FactionType DormitoryFactionType;
        
        public DormitoryConfigWindow()
        {
            InitializeComponent();
            SetFactionListData();
        }
        private void SetFactionListData()
        {
            FactionComboBox.ItemsSource = new[] { "Gryffindor", "Slytherin", "Hufflepuff", "Ravenclaw" };
        }
        private void FloorCountField_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            CaptureValues();
            
            if (DormitoryFloorCount == 0)
            {
                FloorCountField.Foreground = DraculaThemeColors.RedBrush;
                return;
            }

            FloorCountField.Foreground = DraculaThemeColors.GreenBrush;
        }
        private void ConfirmBtn_OnClick(object sender, RoutedEventArgs e)
        {
            CaptureValues();
            
            if (!AllFieldsHaveValidValues()) return;
            
            Dormitory newDormitory = new Dormitory(DormitoryName, DormitoryFloorCount, DormitoryFactionType);

            try
            {
                DormitoryManager.AddDormitory(newDormitory);
            }
            catch (InvalidDormitoryNameException)
            {
                NameField.Foreground = DraculaThemeColors.RedBrush;
                return;
            }
            
            WindowManager.CloseTrackedWindow(this);
        }
        private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            WindowManager.CloseTrackedWindow(this);
        }
        private void DormitoryConfigWindow_OnClosed(object sender, EventArgs e)
        {
            WindowManager.UnTrackWindow(this);
        }
        private void CaptureValues()
        {
            DormitoryName = NameField.Text;
            DormitoryFloorCount = 0;

            int.TryParse(FloorCountField.Text, out DormitoryFloorCount);

            try
            {
                DormitoryFactionType =
                    (FactionType)Enum.Parse(typeof(FactionType), FactionComboBox.SelectionBoxItem.ToString());
            }
            catch (Exception)
            {
                DormitoryFactionType = FactionType.None;
            }
        }
        private bool AllFieldsHaveValidValues()
        {
            return DormitoryName != "" && DormitoryFloorCount != 0 && DormitoryFactionType != FactionType.None;
        }
        private void NameField_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            NameField.Foreground = DraculaThemeColors.WhiteBrush;
        }
    }
}
