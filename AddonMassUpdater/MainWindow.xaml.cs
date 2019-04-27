using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace GetLinks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BackupWTF_Click(object sender, RoutedEventArgs e)
        {
        }

        private void UpdateAddons_Click(object sender, RoutedEventArgs e)
        {
            var instance = new LinkBuilder();
            instance.GetLinks();
            instance.Makeuseablelink();
            //var instance2 = new DownloadFiles();
            //instance2();
        }

        private void UpdaterFolder_Click(object sender, RoutedEventArgs e)
        {
            var workingdirectory = Directory.GetCurrentDirectory();
            System.Diagnostics.Process.Start(workingdirectory);
        }

        private void WoWFolder_Click(object sender, RoutedEventArgs e)
        {
        }

        private void CleanCacheWTF_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void AddonList_TextBox(object sender, TextChangedEventArgs e)
        {
        }

        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
        }

        private void ConsoleControl_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void ProgressBar_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}