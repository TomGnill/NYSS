using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading;
using System.Windows;
using NYSS__Lab2.Models;
using NYSS__Lab2.View;

namespace NYSS__Lab2
{
    public partial class MainWindow : Window
    {
        public static string FilePath { get; set; }
        public ObservableCollection<Data> Data { get; set; }
        private readonly Timer _timer;

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void FullDataGridView_Click(Object sender, RoutedEventArgs e)
        {
            MainWindowFrame.NavigationService.Navigate(new Uri("FullDataGrid.xaml", UriKind.Relative));
        }

        private void ShortDataGridView_Click(Object sender, RoutedEventArgs e)
        {
            MainWindowFrame.NavigationService.Navigate(new Uri("View/ShortDataGrid.xaml", UriKind.Relative));
        }

        private void OpenFileWindow_Click(Object sender, RoutedEventArgs e)
        {
            OpenFileWindow openFileWindow = new OpenFileWindow();
            openFileWindow.Show();
        }

        private void DownloadFile_Click(Object sender, RoutedEventArgs e)
        {
            const string link = @"https://bdu.fstec.ru/files/documents/thrlist.xlsx";
            var webClient = new WebClient();
            webClient.DownloadFile(new Uri(link), "thrlist.xlsx");
            Data = new ObservableCollection<Data>(ExcelParser.GetFullData("thrlist.xlsx"));
            MainWindowFrame.NavigationService.Navigate(new Uri("View/FullDataGrid.xaml", UriKind.Relative));
        }

        private void SaveFile_Click(Object sender, RoutedEventArgs e)
        {
            var saveFileWindow = new SaveFileWindow();
            saveFileWindow.Show();
        }

        private void UpdateData_Click(Object sender, RoutedEventArgs e)
        {
            const string link = @"https://bdu.fstec.ru/files/documents/thrlist.xlsx";
            var webClient = new WebClient();
            webClient.DownloadFile(new Uri(link), "thrlist.xlsx");
            FilePath = "thrlist.xlsx";
            var updateDataWindow = new UpdateDataWindow();
            updateDataWindow.Show();
        }

        private void MainWindow_Loaded(Object sender, EventArgs e)
        {
            var startMenuWindow = new StartMenuWindow();
            startMenuWindow.Show();
        }
    }
}
