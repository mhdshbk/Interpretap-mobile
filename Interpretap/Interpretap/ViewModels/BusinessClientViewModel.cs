﻿using Interpretap.Models;
using Interpretap.Models.RespondModels.InnerTypes;
using Interpretap.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Interpretap.ViewModels
{
    public class BusinessClientViewModel
    {
        BusinessClient _client;
        private int _businessId;

        public string FirstName => _client.ClientFirstName;
        public string LastName => _client.ClientLastName;
        public string UserName => _client.UserName;
        public string Email => _client.ClientEmail;
        public string PhoneNumber => _client.ClientPhoneNumber;
        public string Address => _client.ClientAddress;
        public string City => _client.ClientCity;
        public string Province => _client.ClientProvince;
        public string Id => _client.ClientId;
        public string IsManager
        {
            get
            {
                if (_client.IsManager == "1")
                {
                    return "Yes";
                }
                else
                {
                    return "No";
                }

            }
        }

        public ICommand DeleteCommand { get; set; }

        public bool IsProcessing { get; private set; }

        public BusinessClientViewModel(BusinessClient client, int businessId)
        {
            _client = client;
            _businessId = businessId;

            DeleteCommand = new Command(async () => await ExecuteDeleteCommandAsync());
        }

        private async Task ExecuteDeleteCommandAsync()
        {
            var confirmed = await App.Current.MainPage.DisplayAlert("Warning", "Are you sure?", "Yes", "No");
            if (confirmed)
            {
                await DeleteClientAsync();
            }
        }

        private async Task DeleteClientAsync()
        {
            IsProcessing = true;

            var request = new RemoveClientFromBusinessRequestModel()
            {
                BusinessId = _businessId.ToString(),
                ClientId = _client.ClientId,
            };
            var service = new BusinessService();
            var responce = await service.RemoveClientFromBusiness(request);

            IsProcessing = false;

            var success = responce.Status == true;
            if (success)
            {
                await App.Current.MainPage.DisplayAlert("Success", responce.Message, "OK");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", responce.Message, "OK");
            }
        }

        private async Task GetClientInfoAsync()
        {
            IsProcessing = true;

            //var request = new InterpreterInfoRequestModel()
            //{
            //    InterpreterId = _employee.InterpreterId
            //};
            //var service = new AgencyService();
            //var result = await service.FetchInterpreterInfo(request);

            IsProcessing = false;
        }
    }
}
