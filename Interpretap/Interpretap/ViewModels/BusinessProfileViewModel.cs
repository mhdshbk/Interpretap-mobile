using Interpretap.Common;
using Interpretap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace Interpretap.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class BusinessProfileViewModel
    {
        BusinessInfo _businessInfo { get; set; }

        public string Name
        {
            get => _businessInfo.BusinessName;
            set => _businessInfo.BusinessName = value;
        }

        public string Email
        {
            get => _businessInfo.BusinessEmail;
            set => _businessInfo.BusinessEmail = value;
        }

        public string PhoneNumber
        {
            get => _businessInfo.BusinessPhoneNumber;
            set => _businessInfo.BusinessPhoneNumber = value;
        }

        public string Address
        {
            get => _businessInfo.BusinessAddress;
            set => _businessInfo.BusinessAddress = value;
        }

        public string City
        {
            get => _businessInfo.BusinessCity;
            set => _businessInfo.BusinessCity = value;
        }

        public string Province
        {
            get => _businessInfo.BusinessProvince;
            set => _businessInfo.BusinessProvince = value;
        }

        public string ZipCode
        {
            get => _businessInfo.BusinessZipCode;
            set => _businessInfo.BusinessZipCode = value;
        }

        public bool IsBusy { get; set; }

        public BusinessProfileViewModel()
        {
            _businessInfo = new BusinessInfo();
        }

        public void LoadData(int businessId)
        {
            IsBusy = true;

            var businesses = LocalStorage.LoginResponseLS.UserInfo.ClientInfo.Businesses;
            var selectedBusiness = businesses.FirstOrDefault(b => b.ClientBusinessId == businessId);
            _businessInfo = selectedBusiness.BusinessInfo;

            IsBusy = false;
        }
    }
}
