using Interpretap.Common;
using Interpretap.Models;
using Interpretap.Services;
using Interpretap.Views;
using PropertyChanged;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Interpretap.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class BusinessProfileViewModel
    {
        BusinessInfo _businessOriginalInfo;
        int _businessId;

        BusinessInfo _businessInfo { get; set; }

        public string Name
        {
            get => _businessInfo.BusinessName;
            set
            {
                _businessInfo.BusinessName = value;
                IsDirty = true;
            }
        }

        public string Email
        {
            get => _businessInfo.BusinessEmail;
            set
            {
                _businessInfo.BusinessEmail = value;
                IsDirty = true;
            }
        }

        public string PhoneNumber
        {
            get => _businessInfo.BusinessPhoneNumber;
            set
            {
                _businessInfo.BusinessPhoneNumber = value;
                IsDirty = true;
            }
        }

        public string Address
        {
            get => _businessInfo.BusinessAddress;
            set
            {
                _businessInfo.BusinessAddress = value;
                IsDirty = true;
            }
        }

        public string City
        {
            get => _businessInfo.BusinessCity;
            set
            {
                _businessInfo.BusinessCity = value;
                IsDirty = true;
            }
        }

        public string Province
        {
            get => _businessInfo.BusinessProvince;
            set
            {
                _businessInfo.BusinessProvince = value;
                IsDirty = true;
            }
        }

        public string ZipCode
        {
            get => _businessInfo.BusinessZipCode;
            set
            {
                _businessInfo.BusinessZipCode = value;
                IsDirty = true;
            }
        }

        public ICommand UpdateCommand { get; set; }
        public bool CanExecuteUpdateCommand => IsDirty;

        public ICommand ClientsListCommand { get; set; }

        public bool IsBusy { get; set; }
        public bool IsDirty { get; set; }

        public BusinessProfileViewModel()
        {
            _businessInfo = new BusinessInfo();
            UpdateCommand = new Command(async () => await ExecuteUpdateCommandAsync());
            ClientsListCommand = new Command(ExecuteClientsListCommand);
        }

        private void ExecuteClientsListCommand(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new EmployeesListPage(new BusinessClientsListViewModel(_businessId)));
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
            if (Name != _businessOriginalInfo.BusinessName) return true;
            if (Email != _businessOriginalInfo.BusinessEmail) return true;
            if (PhoneNumber != _businessOriginalInfo.BusinessPhoneNumber) return true;
            if (Address != _businessOriginalInfo.BusinessAddress) return true;
            if (City != _businessOriginalInfo.BusinessCity) return true;
            if (Province != _businessOriginalInfo.BusinessProvince) return true;
            if (ZipCode != _businessOriginalInfo.BusinessZipCode) return true;
            return false;
        }

        public void LoadData(int businessId)
        {
            IsBusy = true;

            var businesses = LocalStorage.LoginResponseLS.UserInfo.ClientInfo.Businesses;
            var selectedBusiness = businesses.FirstOrDefault(b => b.ClientBusinessId == businessId);
            _businessInfo = selectedBusiness.BusinessInfo;
            _businessId = businessId;

            StoreOriginalData();
            IsDirty = false;

            IsBusy = false;
        }

        private void StoreOriginalData()
        {
            _businessOriginalInfo = new BusinessInfo()
            {
                BusinessName = _businessInfo.BusinessName,
                BusinessEmail = _businessInfo.BusinessEmail,
                BusinessPhoneNumber = _businessInfo.BusinessPhoneNumber,
                BusinessAddress = _businessInfo.BusinessAddress,
                BusinessCity = _businessInfo.BusinessCity,
                BusinessProvince = _businessInfo.BusinessProvince,
                BusinessZipCode = _businessInfo.BusinessZipCode,
            };
        }

        public async Task SendUpdateProfileAsync()
        {
            IsBusy = true;

            var updateModel = new BusinessUpdateModel()
            {
                Name = this.Name != _businessOriginalInfo.BusinessName ? this.Name : null,
                Email = this.Email != _businessOriginalInfo.BusinessEmail ? this.Email : null,
                Address = this.Address != _businessOriginalInfo.BusinessAddress ? this.Address : null,
                City = this.City != _businessOriginalInfo.BusinessCity ? this.City : null,
                Province = this.Province != _businessOriginalInfo.BusinessProvince ? this.Province : null,
                ZipCode = this.ZipCode != _businessOriginalInfo.BusinessZipCode ? this.ZipCode : null,
                PhoneNumber = this.PhoneNumber != _businessOriginalInfo.BusinessPhoneNumber ? this.PhoneNumber : null,
                Id = _businessId.ToString()
            };

            var service = new BusinessService();
            var updateResponce = await service.UpdateBusiness(updateModel);

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
            var businesses = loginResponceLS.UserInfo.ClientInfo.Businesses;
            var oldValue = businesses.FirstOrDefault(b => b.ClientBusinessId == _businessId);
            var index = businesses.IndexOf(oldValue);
            if (index != -1)
            {
                loginResponceLS.UserInfo.ClientInfo.Businesses[index].BusinessInfo = _businessInfo;
                LocalStorage.LoginResponseLS = loginResponceLS;
            }
        }
    }
}
