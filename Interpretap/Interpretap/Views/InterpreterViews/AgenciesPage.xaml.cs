using Interpretap.Models;
using Interpretap.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Interpretap.Views.InterpreterViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgenciesPage : ContentPage
    {
        AgenciesViewModel _agenciesViewModel;

        public AgenciesPage()
        {
            InitializeComponent();
            _agenciesViewModel = new AgenciesViewModel();
            listView.ItemsSource = _agenciesViewModel.Agencies;
            this.BindingContext = _agenciesViewModel;
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (((ListView)sender).SelectedItem == null) return;

            var selectedAgency = ((ListView)sender).SelectedItem as AgencyModel;
            _agenciesViewModel.ShowMounthlyCallReportForAgency(selectedAgency);

            ((ListView)sender).SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _agenciesViewModel.LoadDataAsync().GetAwaiter();
        }
    }
}