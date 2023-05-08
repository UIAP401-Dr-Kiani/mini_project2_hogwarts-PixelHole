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
using hogwartsBingus.Session;

namespace hogwartsBingus.UI_Classes
{
    /// <summary>
    /// Interaction logic for ComposeMessageWindow.xaml
    /// </summary>
    public partial class ComposeMessageWindow : Window
    {
        public ComposeMessageWindow()
        {
            InitializeComponent();
        }

        private void ComposeMessageWindow_OnClosed(object sender, EventArgs e)
        {
            WindowManager.UnTrackWindow(this);
        }
    }
}
