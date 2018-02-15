using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
using Interpretap.Models;
using Interpretap.Common;
using Interpretap.Services;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using Interpretap.Views;

namespace Interpretap.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class AgencyProfileViewModel 
    {
        BusinessInfo _agencyOriginalInfo;
        int _agencyId;

        BusinessInfo _agencyInfo { get; set; }

        public string Name
        {
            get => _agencyInfo.BusinessName;
            set
            {
                _agencyInfo.BusinessName = value;
                IsDirty = true;
            }
        }

        public string Email
        {
            get => _agencyInfo.BusinessEmail;
            set
            {
                _agencyInfo.BusinessEmail = value;
                IsDirty = true;
            }
        }

        public string PhoneNumber
        {
            get => _agencyInfo.BusinessPhoneNumber;
            set
            {
                _agencyInfo.BusinessPhoneNumber = value;
                IsDirty = true;
            }
        }

        public string Address
        {
            get => _agencyInfo.BusinessAddress;
            set
            {
                _agencyInfo.BusinessAddress = value;
                IsDirty = true;
            }
        }

        public string City
        {
            get => _agencyInfo.BusinessCity;
            set
            {
                _agencyInfo.BusinessCity = value;
                IsDirty = true;
            }
        }

        public string Province
        {
            get => _agencyInfo.BusinessProvince;
            set
            {
                _agencyInfo.BusinessProvince = value;
                IsDirty = true;
            }
        }

        public string ZipCode
        {
            get => _agencyInfo.BusinessZipCode;
            set
            {
                _agencyInfo.BusinessZipCode = value;
                IsDirty = true;
            }
        }

        public ICommand UpdateCommand { get; set; }
        public bool CanExecuteUpdateCommand => IsDirty;

        public ICommand EmployeeListCommand { get; set; }

        public bool IsBusy { get; set; }
        public bool IsDirty { get; set; }

        public AgencyProfileViewModel()
        {
            _agencyInfo = new BusinessInfo();
            UpdateCommand = new Command(async () => await ExecuteUpdateCommandAsync());
            EmployeeListCommand = new Command(ExecuteEmployeeListCommand);
        }

        private void ExecuteEmployeeListCommand(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new EmployeesListPage(_agencyId)); 
        }

        private async Task ExecuteUpdateCommandAsync()
        {
            if (InfoChanged())
            {
                await SendUpdateProfileAsync(); 
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Warning", "Nothing is changed", "OK");
            }
        }

        bool InfoChanged()
        {
            if (Name != _agencyOriginalInfo.BusinessName) return true;
            if (Email != _agencyOriginalInfo.BusinessEmail) return true;
            if (PhoneNumber != _agencyOriginalInfo.BusinessPhoneNumber) return true;
            if (Address != _agencyOriginalInfo.BusinessAddress) return true;
            if (City != _agencyOriginalInfo.BusinessCity) return true;
            if (Province != _agencyOriginalInfo.BusinessProvince) return true;
            if (ZipCode != _agencyOriginalInfo.BusinessZipCode) return true;
            return false;
        }

        public void LoadData(int agencyId)
        {
            IsBusy = true;

            var agencies = LocalStorage.LoginResponseLS.UserInfo.InterpreterInfo.Agencies;
            var selectedAgency = agencies.FirstOrDefault(b => b.InterpreterBusinessId == agencyId);
            _agencyInfo = selectedAgency.BusinessInfo;
            _agencyId = agencyId;

            StoreOriginalData();
            IsDirty = false;

            IsBusy = false;
        }

        private void StoreOriginalData()
        {
            _agencyOriginalInfo = new BusinessInfo()
            {
                BusinessName = _agencyInfo.BusinessName,
                BusinessEmail = _agencyInfo.BusinessEmail,
                BusinessPhoneNumber = _agencyInfo.BusinessPhoneNumber,
                BusinessAddress = _agencyInfo.BusinessAddress,
                BusinessCity = _agencyInfo.BusinessCity,
                BusinessProvince = _agencyInfo.BusinessProvince,
                BusinessZipCode = _agencyInfo.BusinessZipCode,
            };
        }

        public async Task SendUpdateProfileAsync()
        {
            IsBusy = true;

            var updateModel = new AgencyUpdateModel()
            {
                Name = this.Name != _agencyOriginalInfo.BusinessName ? this.Name : null,
                Email = this.Email != _agencyOriginalInfo.BusinessEmail ? this.Email : null,
                Address = this.Address != _agencyOriginalInfo.BusinessAddress ? this.Address : null,
                City = this.City != _agencyOriginalInfo.BusinessCity ? this.City : null,
                Province = this.Province != _agencyOriginalInfo.BusinessProvince ? this.Province : null,
                ZipCode = this.ZipCode != _agencyOriginalInfo.BusinessZipCode ? this.ZipCode : null,
                PhoneNumber = this.PhoneNumber != _agencyOriginalInfo.BusinessPhoneNumber ? this.PhoneNumber : null,
                Id = _agencyId.ToString()
            };

            var service = new AgencyService();
            var updateResponce = await service.UpdateAgency(updateModel);

            var updateSuccess = updateResponce.Status == true;
            if (!updateSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", updateResponce.Message, "OK");
            }
            else
            {
                UpdateLocalStorage();
                await App.Current.MainPage.DisplayAlert("Notification", updateResponce.Message, "OK");
                IsDirty = false;
            }

            IsBusy = false;
        }

        private void UpdateLocalStorage()
        {
            var loginResponceLS = LocalStorage.LoginResponseLS;
            var agencies = loginResponceLS.UserInfo.InterpreterInfo.Agencies;
            var oldValue = agencies.FirstOrDefault(b => b.InterpreterBusinessId == _agencyId);
            var index = agencies.IndexOf(oldValue);
            if(index != -1)
            {
                loginResponceLS.UserInfo.InterpreterInfo.Agencies[index].BusinessInfo = _agencyInfo;
                LocalStorage.LoginResponseLS = loginResponceLS;
            }
        }
    }
}
