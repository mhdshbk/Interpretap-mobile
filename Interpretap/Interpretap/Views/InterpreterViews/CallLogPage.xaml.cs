using Interpretap.Models;
using Interpretap.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Interpretap.Common.Constants;

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

            listView.ItemSelected += (sender, e) =>
            {
                if (((ListView)sender).SelectedItem == null)
                    return;

                MonthlyCallReportModel selectedCallReport = ((ListView)sender).SelectedItem as MonthlyCallReportModel;
                Navigation.PushAsync(new CallLogDetails(selectedCallReport, UserTypes.Interpreter));
                ((ListView)sender).SelectedItem = null;
            };
            listView.ItemAppearing += ListView_ItemAppearing;
        }

        private void ListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var itemModel = e.Item as MonthlyCallReportModel;
            _viewModel.OnItemAppearingAsync(itemModel).GetAwaiter();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_viewModel.CallLogs.Count == 0)
            {
                _viewModel.LoadData(string.Empty, UserTypes.Interpreter).GetAwaiter();
            }
            else
            {
                if (App.ToUpdateLogsFlag)
                {
                    _viewModel.CallLogs.Clear();
                    _viewModel.LoadData(string.Empty, UserTypes.Interpreter).GetAwaiter();
                    App.ToUpdateLogsFlag = false;
                }
            }
        }
    }
}
