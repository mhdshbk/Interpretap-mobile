using Interpretap.Models;
using Interpretap.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Interpretap.Views.UserViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BusinessesPage : ContentPage
    {
        BusinessesViewModel _businessesViewModel;

        public BusinessesPage()
        {
            InitializeComponent();
            _businessesViewModel = new BusinessesViewModel();
            listView.ItemsSource = _businessesViewModel.Businesses;
            this.BindingContext = _businessesViewModel;
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (((ListView)sender).SelectedItem == null) return;

            var selectedBusiness = ((ListView)sender).SelectedItem as BusinessModel;
            _businessesViewModel.ShowMounthlyCallReportForBusiness(selectedBusiness);

            ((ListView)sender).SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _businessesViewModel.LoadDataAsync().GetAwaiter();
        }
    }
}