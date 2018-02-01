using System;
using System.Windows;
using Gecko;
using System.Windows.Forms.Integration;
using System.Diagnostics;
using ReportTool.Core;
using System.Threading;
using System.Reflection;

namespace ReportTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WindowsFormsHost Host;

        private GeckoWebBrowser Browser;

        private string URL;

        private ReportTask ReportTask;

        private CancellationTokenSource CancellationTokenSource;

        public MainWindow()
        {
            InitializeComponent();
            Gecko.Xpcom.Initialize("Firefox");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Host = new WindowsFormsHost();
            this.Browser = new GeckoWebBrowser();
            this.Host.Child = Browser;
            this.GridWeb.Children.Add(this.Host);

            this.Browser.Navigate("about:blank");
            var field = typeof(GeckoWebBrowser).GetField("WebBrowser", BindingFlags.Instance | BindingFlags.NonPublic);
            if (field != null)
            {
                var val = field.GetValue(Browser); 
                nsIWebBrowser nsIWebBrowser = (nsIWebBrowser)val;
                Xpcom.QueryInterface<nsILoadContext>(nsIWebBrowser).SetPrivateBrowsing(true);
            }
            this.Browser.Navigate("https://m.facebook.com/");
        }

        private void BeatvnTroll_Click(object sender, RoutedEventArgs e)
        {
            this.URL = "https://m.facebook.com/beatvn.troll/";
            this.Browser.Navigate(this.URL);

        }

        private void BeatvnWorld_Click(object sender, RoutedEventArgs e)
        {
            this.URL = "https://m.facebook.com/beatvn.world/";
            this.Browser.Navigate(this.URL);
        }

        private void StartReport_Click(object sender, RoutedEventArgs e)
        {
            this.CancellationTokenSource = new CancellationTokenSource();
            this.ReportTask = new ReportTask();
            this.ReportTask.AsyncStart(this.Browser, this.Browser.Handle, this.URL, this.CancellationTokenSource.Token);
            this.StartReport.Visibility = Visibility.Hidden;
            this.StopReport.Visibility = Visibility.Visible;
        }

        private void StopReport_Click(object sender, RoutedEventArgs e)
        {
            this.CancellationTokenSource.Cancel();
            this.StartReport.Visibility = Visibility.Visible;
            this.StopReport.Visibility = Visibility.Hidden;
        }
    }
}
