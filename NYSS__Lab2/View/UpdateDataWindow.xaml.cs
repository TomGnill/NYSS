using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Windows;
using NYSS__Lab2.Models;

namespace NYSS__Lab2.View
{
    public partial class UpdateDataWindow : Window
    {
        private static readonly MainWindow MainWindow = (MainWindow)System.Windows.Application.Current.MainWindow;
        public UpdateDataWindow()
        {
            InitializeComponent();
        }

        private void UpdateDataWindow_Initialized(object sender, EventArgs e)
        {
            const String link = @"https://bdu.fstec.ru/files/documents/thrlist.xlsx";
            var webClient = new WebClient();
            webClient.DownloadFile(new Uri(link), "thrlist.xlsx");
            MainWindow.FilePath = "thrlist.xlsx";

            try
            {
                var result = DataMerger
                    .Compare(MainWindow.Data, new ObservableCollection<Data>(ExcelParser.GetFullData(MainWindow.FilePath)));
                var comparisonPage = new ComparisonPage(result);
                UpdateDataWindowFrame.Navigate(comparisonPage);
            }
            catch (Exception exception)
            {
                var badComparisonPage = new BadComparisonPage(exception.Message);
                UpdateDataWindowFrame.Navigate(badComparisonPage);
            }
        }
    }
}
