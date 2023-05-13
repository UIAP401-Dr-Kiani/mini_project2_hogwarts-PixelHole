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

namespace hogwartsBingus.UI_Classes.Dialogs
{
    /// <summary>
    /// Interaction logic for SavingDataDialog.xaml
    /// </summary>
    public partial class SavingDataDialog : Window
    {
        private bool AutoClose;
        public SavingDataDialog(bool autoClose)
        {
            InitializeComponent();
            AutoClose = autoClose;
        }

        public void SetProgress(int progress)
        {
            SaveProgressBar.Value = progress;
            if (AutoClose && progress == 100)
            {
                WindowManager.CloseTrackedWindow(this);
            }
        }

        private void SavingDataDialog_OnClosed(object sender, EventArgs e)
        {
            WindowManager.UnTrackWindow(this);
        }
    }
}
