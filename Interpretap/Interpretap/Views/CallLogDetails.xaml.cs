using Interpretap.Models;
using Interpretap.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Interpretap.Common.Constants;

namespace Interpretap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CallLogDetails : ContentPage
    {
        private CallLogDetailsViewModel _viewModel { get; set; }
        private MonthlyCallReportModel _monthlyCallReportModel;
        private UserTypes _userType;

        public CallLogDetails(MonthlyCallReportModel monthlyCallReportModel, UserTypes userType)
        {
            InitializeComponent();

            _monthlyCallReportModel = monthlyCallReportModel;
            _userType = userType;
            Lbl_Title.Text = _monthlyCallReportModel.DateFromTo;

            _viewModel = new CallLogDetailsViewModel();
            BindingContext = _viewModel;

            listView.ItemsSource = _viewModel.CallLogs;

            listView.ItemSelected += (sender, e) =>
            {
                if (((ListView)sender).SelectedItem == null) return; 
                FifteenCallModel selectedCall = ((ListView)sender).SelectedItem as FifteenCallModel;
                //DisplayAlert("Item Selected", selectedCall., "Ok");
                Navigation.PushAsync(new CallInfo(selectedCall));
                ((ListView)sender).SelectedItem = null;
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if(_monthlyCallReportModel != null && _viewModel.CallLogs.Count == 0)
            _viewModel.LoadData(_monthlyCallReportModel.EndOfMonth,
                _monthlyCallReportModel.StartOfMonth,
                _monthlyCallReportModel.EndOfMonth,
                _userType).GetAwaiter();
        }
    }
}