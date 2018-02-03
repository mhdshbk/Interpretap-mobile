using Interpretap.Common;
using Interpretap.Models;
using Interpretap.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Interpretap.CustomElements
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientProfileContentView : ContentView
    {
        UserModel _user;
        UserModel _userOld;

        public ClientProfileContentView()
        {
            InitializeComponent();
            SetActivityIndicatorState(false);
            UpdatePage();
        }

        private void UpdatePage()
        {
            _user = LocalStorage.LoginResponseLS.UserInfo;
            _userOld = _user;

            Entry_Password.Text = "";
            Entry_Password_Confirm.Text = "";
            Entry_First_Name.Text = _user.FirstName;
            Entry_Last_Name.Text = _user.LastName;
            Entry_Email.Text = _user.Email;
            Entry_Phone_Number.Text = _user.PhoneNumber;
            Entry_City.Text = _user.City;
            Entry_Address.Text = _user.Address;
            Entry_Province.Text = _user.Province;
            Entry_Zip_Code.Text = _user.ZipCode;
        }

        private async Task UpdateUserProfile(object sender, EventArgs e)
        {
            SetActivityIndicatorState(true);

            var updateModel = new UpdateModel();

            _user.FirstName = _userOld.FirstName != Entry_First_Name.Text ? Entry_First_Name.Text : null;
            _user.LastName = _userOld.LastName != Entry_Last_Name.Text ? Entry_Last_Name.Text : null;
            _user.Email = _userOld.Email != Entry_Email.Text ? Entry_Email.Text : null;
            _user.PhoneNumber = _userOld.PhoneNumber != Entry_Phone_Number.Text ? Entry_Phone_Number.Text : null;
            _user.City = _userOld.City != Entry_City.Text ? Entry_City.Text : null;
            _user.Address = _userOld.Address != Entry_Address.Text ? Entry_Address.Text : null;
            _user.Province = _userOld.Province != Entry_Province.Text ? Entry_Province.Text : null;
            _user.ZipCode = _userOld.ZipCode != Entry_Zip_Code.Text ? Entry_Zip_Code.Text : null;

            var nothingToUpdate = true;
            if (!string.IsNullOrEmpty(_user.FirstName))
            {
                nothingToUpdate = false;
            }
            if (!string.IsNullOrEmpty(_user.LastName))
            {
                nothingToUpdate = false;
            }
            if (!string.IsNullOrEmpty(_user.Email))
            {
                nothingToUpdate = false;
            }
            if (!string.IsNullOrEmpty(_user.PhoneNumber))
            {
                nothingToUpdate = false;
            }
            if (!string.IsNullOrEmpty(_user.City))
            {
                nothingToUpdate = false;
            }
            if (!string.IsNullOrEmpty(_user.Address))
            {
                nothingToUpdate = false;
            }
            if (!string.IsNullOrEmpty(_user.Province))
            {
                nothingToUpdate = false;
            }
            if (!string.IsNullOrEmpty(_user.ZipCode))
            {
                nothingToUpdate = false;
            }

            if (nothingToUpdate)
            {
                await App.Current.MainPage.DisplayAlert("Message", "Nothing is changed", "Ok");
                UpdatePage();
                SetActivityIndicatorState(false);
                return;
            };

            updateModel.Password = !string.IsNullOrEmpty(Entry_Password.Text) ? Entry_Password.Text : "";
            updateModel.PasswordConfirmation = !string.IsNullOrEmpty(Entry_Password_Confirm.Text) ? Entry_Password_Confirm.Text : "";
            updateModel.FirstName = _user.FirstName;
            updateModel.Email = _user.Email;
            updateModel.LastName = _user.LastName;
            updateModel.PhoneNumber = _user.PhoneNumber;
            updateModel.City = _user.City;
            updateModel.Address = _user.Address;
            updateModel.Province = _user.Province;
            updateModel.ZipCode = _user.ZipCode;

            UserService _userService = new UserService();
            var updateUserRespond = await _userService.UpdateUser(updateModel);

            var updateSuccess = updateUserRespond.Status;
            if (updateSuccess)
            {
                var loginInfo = LocalStorage.LoginResponseLS;
                if (!string.IsNullOrEmpty(_user.FirstName))
                {
                    loginInfo.UserInfo.FirstName = _user.FirstName;
                }
                if (!string.IsNullOrEmpty(_user.LastName))
                {
                    loginInfo.UserInfo.LastName = _user.LastName;
                }
                if (!string.IsNullOrEmpty(_user.Email))
                {
                    loginInfo.UserInfo.Email = _user.Email;
                }
                if (!string.IsNullOrEmpty(_user.PhoneNumber))
                {
                    loginInfo.UserInfo.PhoneNumber = _user.PhoneNumber;
                }
                if (!string.IsNullOrEmpty(_user.City))
                {
                    loginInfo.UserInfo.City = _user.City;
                }
                if (!string.IsNullOrEmpty(_user.Address))
                {
                    loginInfo.UserInfo.Address = _user.Address;
                }
                if (!string.IsNullOrEmpty(_user.Province))
                {
                    loginInfo.UserInfo.Province = _user.Province;
                }
                if (!string.IsNullOrEmpty(_user.ZipCode))
                {
                    loginInfo.UserInfo.ZipCode = _user.ZipCode;
                }
                LocalStorage.LoginResponseLS = loginInfo;
                UpdatePage();
            }

            await App.Current.MainPage.DisplayAlert("Message", updateUserRespond.Message, "Ok");
            SetActivityIndicatorState(false);
        }

        private async Task LogoutButtonClickedAsync(object sender, EventArgs e)
        {
            SetActivityIndicatorState(true);
            await App.LogoutAsync();
        }

        private void SetActivityIndicatorState(bool enable)
        {
            if (enable)
            {
                ActivityIndicator.IsVisible = true;
                ControlsView.IsVisible = false;
            }
            else
            {
                ActivityIndicator.IsVisible = false;
                ControlsView.IsVisible = true;
            }
        }
    }
}