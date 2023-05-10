using hogwartsBingus.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace hogwartsBingus.UI_Classes.Ceremony
{
    /// <summary>
    /// Interaction logic for WeeklyScheduleUpdaterWindow.xaml
    /// </summary>
    public partial class WeeklyScheduleUpdaterWindow : Window
    {
        public WeeklyScheduleUpdaterWindow()
        {
            InitializeComponent();
            string[,] test = new string[10,5];
            for(int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    test[j, i] = (i +  j).ToString();
                }
            }

            WeeklyScheduleTable.ItemsSource = test;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            WindowManager.UnTrackWindow(this);
        }
    }
}
