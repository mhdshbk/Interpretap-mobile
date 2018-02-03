using Interpretap.Common;
using PropertyChanged;
using System.Collections.ObjectModel;
using static Interpretap.Common.Constants;
using System;
using Interpretap.Models;

namespace Interpretap.ViewModels
{
    public class ProfileSelectorItemViewModel
    {
        public string ProfileName { get; set; }
        public string ProfileTypeCaption { get; set; }
        public int ClientBusinessId { get; set; }
        public int InterpreterBusinessId { get; set; }
    }

    [AddINotifyPropertyChangedInterface]
    public class ProfileViewModel
    {
        UserModel _userInfo => LocalStorage.LoginResponseLS.UserInfo;

        public ObservableCollection<ProfileSelectorItemViewModel> Profiles { get; set; }
        public ProfileSelectorItemViewModel SelectedProfile { get; set; }

        public UserTypes UserType => App.User.UserType;

        public ProfileViewModel()
        {
            LoadProfileSelectorItems();
        }

        private void LoadProfileSelectorItems()
        {
            Profiles = new ObservableCollection<ProfileSelectorItemViewModel>();

            if (UserType == UserTypes.Client)
            {
                AddClientProfileItem();
                AddBusinesses();
            }
            if (UserType == UserTypes.Interpreter)
            {
                AddInterpreterProfileItem();
                AddAgencies();
            }
            SelectedProfile = Profiles[0];
        }

        private void AddClientProfileItem()
        {
            var clientProfileItem = new ProfileSelectorItemViewModel()
            {
                ProfileName = $"{_userInfo.FirstName} {_userInfo.LastName}",
                ProfileTypeCaption = "Client",
            };
            Profiles.Add(clientProfileItem);
        }

        private void AddInterpreterProfileItem()
        {
            var interpreterProfileItem = new ProfileSelectorItemViewModel()
            {
                ProfileName = $"{_userInfo.FirstName} {_userInfo.LastName}",
                ProfileTypeCaption = "Interpreter",
            };
            Profiles.Add(interpreterProfileItem);
        }

        private void AddBusinesses()
        {
            foreach (var business in LocalStorage.LoginResponseLS.UserInfo.ClientInfo.Businesses)
            {
                var businessProfileItem = new ProfileSelectorItemViewModel()
                {
                    ProfileName = business.BusinessInfo.BusinessName,
                    ProfileTypeCaption = "Business",
                };
                Profiles.Add(businessProfileItem);
            }
        }

        private void AddAgencies()
        {
            foreach (var agency in LocalStorage.LoginResponseLS.UserInfo.InterpreterInfo.Agencies)
            {
                var agencyProfileItem = new ProfileSelectorItemViewModel()
                {
                    ProfileName = agency.BusinessInfo.BusinessName,
                    ProfileTypeCaption = "Agency",
                };
                Profiles.Add(agencyProfileItem);
            }
        }
    }
}
