using System;
using System.Windows;
using hogwartsBingus.Execptions;
using hogwartsBingus.Session;

namespace hogwartsBingus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login()
        {
            string username = "", password = "";

            try
            {
                SessionManager.Login(username, password);
            }
            catch (LoginNotFoundException e)
            {
                
            }
        }
    }
}