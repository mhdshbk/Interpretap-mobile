using Interpretap.Models;
using Interpretap.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Interpretap.Views.InterpreterViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CallLogPage : ContentPage
    {
        private CallLogViewModel _viewModel { get; set; }

        public CallLogPage()
        {
            InitializeComponent();

            _viewModel = new CallLogViewModel();
            BindingContext = _viewModel;

            listView.ItemsSource = _viewModel.CallLogs;

            listView.ItemSelected += (sender, e) => {
                MonthlyCallReportModel selectedCallReport = ((ListView)sender).SelectedItem as MonthlyCallReportModel;
                DisplayAlert("Item Selected", selectedCallReport.DateFromTo, "Ok");
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.LoadData(DateTime.Now.ToString("yyyy-MM-dd")).GetAwaiter();
        }
    }
}
