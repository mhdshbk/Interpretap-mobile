using Interpretap.Models;
using Interpretap.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using PropertyChanged;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Interpretap.ViewModels;

namespace Interpretap.Views.UserViews
{
    [AddINotifyPropertyChangedInterface]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddClientToBusinessPage : ContentPage
    {
        int _businessId;
        BusinessClientsListViewModel _parentViewModel;

        public bool IsProcessing { get; private set; }
        public bool CanAddClient { get; private set; }

        public AddClientToBusinessPage(BusinessClientsListViewModel parentViewModel)
        {
            _businessId = parentViewModel.BusinessId;
            _parentViewModel = parentViewModel;
            InitializeComponent();

            this.BindingContext = this;
        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            AddClientToBusinessAsync();
        }

        private async Task AddClientToBusinessAsync()
        {
            IsProcessing = true;

            var request = new AddClientToBusinessRequestModel()
            {
                BusinessId = _businessId.ToString(),
                ClientId = lblId.Text,
                IsManager = SwitchIsManager.IsToggled ? "1" : "0",
            };

            var service = new BusinessService();
            var responce = await service.AddClientToBusiness(request);

            IsProcessing = false;

            var success = responce.Status == true;
            if (success)
            {
                _parentViewModel.RefreshCommand.Execute(null);
                await App.Current.MainPage.DisplayAlert("Success", responce.Message, "OK");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", responce.Message, "OK");
            }
        }

        private void lblId_TextChanged(object sender, TextChangedEventArgs e)
        {
            CanAddClient = !string.IsNullOrEmpty(lblId.Text);
        }
    }
}