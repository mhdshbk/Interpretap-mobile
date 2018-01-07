using Interpretap.Models;
using Interpretap.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Interpretap.Common.Constants;

namespace Interpretap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CallLogDetailsAB : ContentPage
    {
        private CallLogDetailsViewModel _viewModel { get; set; }
        private MonthlyCallReportModel _monthlyCallReportModel;
        private UserTypes _userType;

        public CallLogDetailsAB(MonthlyCallReportModel monthlyCallReportModel, UserTypes userType)
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
                FifteenCallModel selectedCall = ((ListView)sender).SelectedItem as FifteenCallModel;
                //DisplayAlert("Item Selected", selectedCall., "Ok");
                ((ListView)sender).SelectedItem = null;
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (_monthlyCallReportModel != null && _viewModel.CallLogs.Count == 0)
                _viewModel.LoadData(DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00",
                    _monthlyCallReportModel.StartOfMonth,
                    _monthlyCallReportModel.EndOfMonth,
                    _userType).GetAwaiter();
        }

        private async Task ShowReportProcedure(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReportPage(_monthlyCallReportModel, _userType));
        }
    }
}