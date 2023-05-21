using System;
using System.Windows;
using System.Windows.Controls;

namespace TestUIApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            kos.Margin = TopLeftPosition(new Thickness(kos.Width / 2 + 5, kos.Height / 2 + 5, 0, 0));
        }

        public Thickness TopLeftPosition(Thickness centerPos)
        {
            return new Thickness(centerPos.Left - 200, centerPos.Top - 150, 0, 0);
        }
        private void Stupid(object sender,RoutedEventArgs routedEventArgs)
        {
            pedaret.Content = "kos nagoo momen";
        }
    }
}