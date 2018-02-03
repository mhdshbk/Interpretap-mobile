using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
using Interpretap.Models;
using Interpretap.Common;

namespace Interpretap.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class AgencyProfileViewModel
    {
        BusinessInfo _agencyInfo { get; set; }

        public string Name
        {
            get => _agencyInfo.BusinessName;
            set => _agencyInfo.BusinessName = value;
        }

        public string Email
        {
            get => _agencyInfo.BusinessEmail;
            set => _agencyInfo.BusinessEmail = value;
        }

        public string PhoneNumber
        {
            get => _agencyInfo.BusinessPhoneNumber;
            set => _agencyInfo.BusinessPhoneNumber = value;
        }

        public string Address
        {
            get => _agencyInfo.BusinessAddress;
            set => _agencyInfo.BusinessAddress = value;
        }

        public string City
        {
            get => _agencyInfo.BusinessCity;
            set => _agencyInfo.BusinessCity = value;
        }

        public string Province
        {
            get => _agencyInfo.BusinessProvince;
            set => _agencyInfo.BusinessProvince = value;
        }

        public string ZipCode
        {
            get => _agencyInfo.BusinessZipCode;
            set => _agencyInfo.BusinessZipCode = value;
        }

        public bool IsBusy { get; set; }

        public AgencyProfileViewModel()
        {
            _agencyInfo = new BusinessInfo();
        }

        public void LoadData(int agencyId)
        {
            IsBusy = true;

            var agencies = LocalStorage.LoginResponseLS.UserInfo.InterpreterInfo.Agencies;
            var selectedAgencies = agencies.FirstOrDefault(b => b.InterpreterBusinessId == agencyId);
            _agencyInfo = selectedAgencies.BusinessInfo;

            IsBusy = false;
        }
    }
}
