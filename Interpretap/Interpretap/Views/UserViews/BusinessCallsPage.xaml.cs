using Interpretap.Models;
using Interpretap.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Interpretap.Common.Constants;

namespace Interpretap.Views.UserViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BusinessCallsPage : ContentPage
    {
        private CallLogViewModel _viewModel { get; set; }

        public BusinessCallsPage(BusinessModel business = null)
        {
            InitializeComponent();

            _viewModel = new CallLogViewModel() { Business = business };
            BindingContext = _viewModel;

            listView.ItemsSource = _viewModel.CallLogs;

            listView.ItemSelected += (sender, e) =>
            {
                if (((ListView)sender).SelectedItem == null)
                    return;

                MonthlyCallReportModel selectedCallReport = ((ListView)sender).SelectedItem as MonthlyCallReportModel;
                var callLogDetailsPage = new CallLogDetailsAB(selectedCallReport, UserTypes.Business);
                callLogDetailsPage.Business = _viewModel?.Business;
                Navigation.PushAsync(callLogDetailsPage);
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
                _viewModel.LoadData(string.Empty, UserTypes.Business).GetAwaiter();
        }
    }
}