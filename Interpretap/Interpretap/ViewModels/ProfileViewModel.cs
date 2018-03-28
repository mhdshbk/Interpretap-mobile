using Interpretap.Common;
using Interpretap.Models;
using PropertyChanged;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using static Interpretap.Common.Constants;

namespace Interpretap.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ProfileSelectorItemViewModel
    {
        public string ProfileName { get; set; }
        public string ProfileTypeCaption { get; set; }
        public UserTypes ProfileType { get; set; }
        public int ClientBusinessId { get; set; }
        public int InterpreterBusinessId { get; set; }
        public bool IsSelected { get; set; }
        public ImageSource ProfileTypeImage { get; set; }
    }

    [AddINotifyPropertyChangedInterface]
    public class ProfileViewModel
    {
        UserModel _userInfo => LocalStorage.LoginResponseLS.UserInfo;

        public ObservableCollection<ProfileSelectorItemViewModel> Profiles { get; set; }
        public ProfileSelectorItemViewModel SelectedProfile { get; private set; }

        public UserTypes UserType => App.User.UserType;

        public object ProfileTypeImage { get; private set; }

        public ProfileViewModel()
        {
            LoadProfileSelectorItems();
        }

        public void SelectProfile(ProfileSelectorItemViewModel profile)
        {
            foreach (var p in Profiles)
            {
                if (p == profile)
                {
                    p.IsSelected = true;
                }
                else
                {
                    p.IsSelected = false;
                }
            }
            SelectedProfile = profile;
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
            SelectProfile(Profiles[0]);
        }

        private void AddClientProfileItem()
        {
            var clientProfileItem = new ProfileSelectorItemViewModel()
            {
                ProfileName = $"{_userInfo.FirstName} {_userInfo.LastName}",
                ProfileTypeCaption = "Client",
                ProfileType = UserTypes.Client,
                ProfileTypeImage = ImageSource.FromFile("user_outline.png"),
            };
            Profiles.Add(clientProfileItem);
        }

        private void AddInterpreterProfileItem()
        {
            var interpreterProfileItem = new ProfileSelectorItemViewModel()
            {
                ProfileName = $"{_userInfo.FirstName} {_userInfo.LastName}",
                ProfileTypeCaption = "Interpreter",
                ProfileType = UserTypes.Interpreter,
                ProfileTypeImage = ImageSource.FromFile("user_outline.png"),
            };
            Profiles.Add(interpreterProfileItem);
        }

        private void AddBusinesses()
        {
            foreach (var business in LocalStorage.LoginResponseLS.UserInfo.ClientInfo.Businesses)
            {
                var businessProfileItem = new ProfileSelectorItemViewModel()
                {
                    ClientBusinessId = business.ClientBusinessId,
                    ProfileName = business.BusinessInfo.BusinessName,
                    ProfileTypeCaption = "Business",
                    ProfileType = UserTypes.Business,
                    ProfileTypeImage = ImageSource.FromFile("briefbag.png"),
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
                    InterpreterBusinessId = agency.InterpreterBusinessId,
                    ProfileName = agency.BusinessInfo.BusinessName,
                    ProfileTypeCaption = "Agency",
                    ProfileType = UserTypes.Agency,
                    ProfileTypeImage = ImageSource.FromFile("briefbag.png"),
                };
                Profiles.Add(agencyProfileItem);
            }
        }
    }
}
