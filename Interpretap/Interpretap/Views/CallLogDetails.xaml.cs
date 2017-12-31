using Interpretap.Models;
using Interpretap.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public CallLogDetails(MonthlyCallReportModel monthlyCallReportModel)
        {
            InitializeComponent();

            _monthlyCallReportModel = monthlyCallReportModel;
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
            if(_monthlyCallReportModel != null)
            _viewModel.LoadData(DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00",
                _monthlyCallReportModel.StartOfMonth,
                _monthlyCallReportModel.EndOfMonth,
                UserTypes.Interpreter).GetAwaiter();
        }
    }
}