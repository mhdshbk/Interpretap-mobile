using Interpretap.Models;
using Interpretap.Services;
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
            listView.ItemAppearing += ListView_ItemAppearing;
        }

        private void ListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var itemModel = e.Item as FifteenCallModel;
            _viewModel.OnItemAppearingAsync(itemModel).GetAwaiter();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (_monthlyCallReportModel != null && _viewModel.CallLogs.Count == 0)
            {
                _viewModel.LoadData(_monthlyCallReportModel.EndOfMonth,
                    _monthlyCallReportModel.StartOfMonth,
                    _monthlyCallReportModel.EndOfMonth,
                    _userType).GetAwaiter();
            }
        }

        private void ButtonShowReportClicked(object sender, EventArgs e)
        {
            var reportPage = new CallReportPage(_monthlyCallReportModel.StartOfMonth, _monthlyCallReportModel.EndOfMonth, _userType);
            Navigation.PushAsync(reportPage);
        }
    }
}