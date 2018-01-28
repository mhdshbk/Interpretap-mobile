using Interpretap.Models;
using Interpretap.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Interpretap.Common.Constants;

namespace Interpretap.Views.UserViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CallLogPage : ContentPage
    {
        private CallLogViewModel _viewModel { get; set; }
        private ActiveCallViewModel _activeCallViewModel;

        public CallLogPage()
        {
            InitializeComponent();

            _viewModel = new CallLogViewModel();
            BindingContext = _viewModel;

            _activeCallViewModel = new ActiveCallViewModel();
            ActiveCallView.BindingContext = _activeCallViewModel;
            _activeCallViewModel.CallCanceled += _activeCallViewModel_CallCanceled;


            listView.ItemsSource = _viewModel.CallLogs;

            listView.ItemSelected += (sender, e) =>
            {
                if (((ListView)sender).SelectedItem == null)
                    return;

                MonthlyCallReportModel selectedCallReport = ((ListView)sender).SelectedItem as MonthlyCallReportModel;
                Navigation.PushAsync(new CallLogDetails(selectedCallReport, UserTypes.Client));
                ((ListView)sender).SelectedItem = null;
            };
        }

        private void _activeCallViewModel_CallCanceled(object sender, EventArgs e)
        {
            ReloadCallLog();
        }

        private void ReloadCallLog()
        {
            _viewModel.CallLogs.Clear();
            _viewModel.LoadData(string.Empty, UserTypes.Client).GetAwaiter();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (_viewModel.CallLogs.Count == 0)
            {
                _viewModel.LoadData(string.Empty, UserTypes.Client).GetAwaiter();
            }
            else
            {
                if (App.ToUpdateLogsFlag)
                {
                    _viewModel.CallLogs.Clear();
                    _viewModel.LoadData(string.Empty, UserTypes.Client).GetAwaiter();
                }
            }
            _activeCallViewModel.OnAppearing();
        }
    }
}
