using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;

#pragma warning disable ET002 // Namespace does not match file path or default namespace

namespace GetLinks
#pragma warning restore ET002 // Namespace does not match file path or default namespace
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private const int GWL_STYLE = -16;

        private const int WS_MAXIMIZEBOX = 0x10000; //maximize button

        public MainWindow()
        {
            InitializeComponent();
            this.SourceInitialized += MainWindow_SourceInitialized;
        }

        private IntPtr _windowHandle;

        private void MainWindow_SourceInitialized(object sender, EventArgs e)
        {
            _windowHandle = new WindowInteropHelper(this).Handle;

            //disable minimize button
            DisableMinimizeButton();
        }

        protected void DisableMinimizeButton()
        {
            if (_windowHandle == IntPtr.Zero)
                throw new InvalidOperationException("The window has not yet been completely initialized");

            SetWindowLong(_windowHandle, GWL_STYLE, GetWindowLong(_windowHandle, GWL_STYLE) & ~WS_MAXIMIZEBOX);
        }

        private void BackupWTF_Click(object sender, RoutedEventArgs e)
        {
        }

        private void UpdateAddons_Click(object sender, RoutedEventArgs e)
        {
            var instance = new LinkBuilder();
            instance.GetLinks();
            instance.Makeuseablelink();
            instance.Downloader();
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