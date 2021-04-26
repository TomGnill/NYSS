using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using NYSS__Lab2.Models;

namespace NYSS__Lab2.View
{
    public partial class ComparisonPage : Page
    {
        private readonly List<MergedData> _mergedData;
        private Int32 _currentPage;
        public ComparisonPage(List<MergedData> mergedData)
        {
            InitializeComponent();
            _mergedData = mergedData;
            totalPages.Text = _mergedData.Count.ToString();
            _currentPage = _mergedData.Count > 0 ? 1 : 0;
            currentPage.Text = _currentPage.ToString();
        }

        private void GoToPageButton_Click(Object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(pageNumber.Text, out int pageNumberResult))
            {
                MessageBox.Show("Введённое значение не является числом!", "Ошибка", MessageBoxButton.OK);
                pageNumber.Text = string.Empty;
                return;
            }

            if (pageNumberResult > _mergedData.Count || pageNumberResult < 1)
            {
                MessageBox.Show($"Страницы под номером {pageNumberResult} не существует!", "Ошибка",
                    MessageBoxButton.OK);
                pageNumber.Text = string.Empty;
                return;
            }
            _currentPage = pageNumberResult;
            pageNumber.Text = string.Empty;
            GeneratePageContent(_currentPage);
        }

        private void PreviousPageButton_Click(Object sender, RoutedEventArgs e)
        {
            _currentPage = int.Parse(currentPage.Text);
            if (_currentPage > 1)
                GeneratePageContent(_currentPage - 1);
        }

        private void NextPageButton_Click(Object sender, RoutedEventArgs e)
        {
            _currentPage = int.Parse(currentPage.Text);
            if (_currentPage < _mergedData.Count)
                GeneratePageContent(_currentPage + 1);
        }

        private void GeneratePageContent(int pageNum)
        {
            var pageContent = _mergedData.Skip(pageNum - 1).Take(1).First();
            var items = new List<ComparisonItem>
            {
                new ComparisonItem()
                {
                    Parameter = "Id", OldParameterValue = pageContent.OldData.Id.ToString(), NewParameterValue = "нет изменений"
                },
                new ComparisonItem() {OldParameterValue = "БЫЛО", NewParameterValue = "СТАЛО"},
                new ComparisonItem()
                {
                    Parameter = "Название угрозы",
                    OldParameterValue = ProcessChange(pageContent.OldData.Name, pageContent.NewData.Name).Key,
                    NewParameterValue = ProcessChange(pageContent.OldData.Name, pageContent.NewData.Name).Value
                },
                new ComparisonItem()
                {
                    Parameter = "Описание угрозы",
                    OldParameterValue = ProcessChange(pageContent.OldData.Description, pageContent.NewData.Description).Key,
                    NewParameterValue = ProcessChange(pageContent.OldData.Description, pageContent.NewData.Description).Value
                },
                new ComparisonItem()
                {
                    Parameter = "Источник угрозы",
                    OldParameterValue = ProcessChange(pageContent.OldData.Source, pageContent.NewData.Source).Key,
                    NewParameterValue = ProcessChange(pageContent.OldData.Source, pageContent.NewData.Source).Value
                },
                new ComparisonItem()
                {
                    Parameter = "Объект воздействия угрозы",
                    OldParameterValue = ProcessChange(pageContent.OldData.Target, pageContent.NewData.Target).Key,
                    NewParameterValue = ProcessChange(pageContent.OldData.Target, pageContent.NewData.Target).Value
                },
                new ComparisonItem()
                {
                    Parameter = "Название угрозы",
                    OldParameterValue = ProcessChange(pageContent.OldData.ConfidentialityOffense, pageContent.NewData.ConfidentialityOffense).Key,
                    NewParameterValue = ProcessChange(pageContent.OldData.ConfidentialityOffense, pageContent.NewData.ConfidentialityOffense).Value
                },
                new ComparisonItem()
                {
                    Parameter = "Название угрозы",
                    OldParameterValue = ProcessChange(pageContent.OldData.ContinuityOffense, pageContent.NewData.ContinuityOffense).Key,
                    NewParameterValue = ProcessChange(pageContent.OldData.ContinuityOffense, pageContent.NewData.ContinuityOffense).Value
                },
                new ComparisonItem()
                {
                    Parameter = "Название угрозы",
                    OldParameterValue = ProcessChange(pageContent.OldData.AvailabilityOffense, pageContent.NewData.AvailabilityOffense).Key,
                    NewParameterValue = ProcessChange(pageContent.OldData.AvailabilityOffense, pageContent.NewData.AvailabilityOffense).Value
                }
            };

            _currentPage = pageNum;
            currentPage.Text = _currentPage.ToString();
            ListBoxData.ItemsSource = items;
        }

        private KeyValuePair<string, string> ProcessChange(string oldValue, string newValue)
        {
            return oldValue == newValue
                ? new KeyValuePair<string, string>(oldValue, "нет изменений")
                : new KeyValuePair<string, string>(oldValue, newValue);
        }
    }
}
