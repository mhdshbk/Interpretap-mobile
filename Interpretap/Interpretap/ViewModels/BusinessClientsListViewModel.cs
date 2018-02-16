using Interpretap.Interfaces.ViewModels;
using Interpretap.Models;
using Interpretap.Models.RespondModels;
using Interpretap.Models.RespondModels.InnerTypes;
using Interpretap.Services;
using Interpretap.Views.UserViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpretap.ViewModels
{
    public class BusinessClientsListViewModel : EmployeesListBaseViewModel
    {
        int _businessId;

        public BusinessClientsListViewModel(int businessId) : base()
        {
            _businessId = businessId;
        }

        protected override async Task ExecuteAddCommandAsync()
        {
            //await App.Current.MainPage.Navigation.PushAsync(new AddInterpreterToAgencyPage(_agencyId));
        }

        protected override async Task LoadDataAsync()
        {
            IsRefreshing = true;

            var clients = await FetchDataAsync();
            FillEmployeesList(clients);

            IsRefreshing = false;
        }

        private async Task<BusinessClient[]> FetchDataAsync()
        {
            var request = new BusinessClientsRequestModel()
            {
                BusinessId = _businessId.ToString(),
                FromClientId = string.Empty,
            };

            var service = new BusinessService();
            var responce = await service.FetchClientsForBusiness(request);
            return responce.BusinessClients;
        }

        private void FillEmployeesList(BusinessClient[] clients)
        {
            if (clients != null)
            {
                foreach (var i in clients)
                {
                    var itemVM = new BusinessClientsListItemViewModel(i);
                    Employees.Add(itemVM);
                }
            }
        }

        public override void OnItemSelected(IEmployeeListItemViewModel selectedItem)
        {
            var item = selectedItem as BusinessClientsListItemViewModel;
            App.Current.MainPage.Navigation.PushAsync(new ClientProfilePage(item.Client, _businessId));
        }
    }
}
