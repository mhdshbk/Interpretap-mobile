using Interpretap.Common;
using Interpretap.Models;
using Interpretap.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Interpretap.Views.InterpreterViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();

            UserModel user = LocalStorage.LoginResponseLS.UserInfo;
            Entry_Password.Text = "";
            Entry_Password_Confirm.Text = "";
            Entry_First_Name.Text = user.FirstName;
            Entry_Last_Name.Text = user.LastName;
            Entry_Email.Text = user.Email;
            Entry_Phone_Number.Text = user.PhoneNumber;
            Entry_City.Text = user.City;
            Entry_Address.Text = user.Address;
            Entry_Province.Text = user.Province;
            Entry_Zip_Code.Text = user.ZipCode;

        }

        private async Task UpdateUserProfile(object sender, EventArgs e)
        {
            var registrationModel = new RegisterModel();
            registrationModel.Password = Entry_Password.Text;
            registrationModel.PasswordConfirmation = Entry_Password_Confirm.Text;
            registrationModel.FirstName = Entry_First_Name.Text;
            registrationModel.Email = Entry_Email.Text;
            registrationModel.LastName = Entry_Last_Name.Text;
            registrationModel.PhoneNumber = Entry_Phone_Number.Text;
            registrationModel.City = Entry_City.Text;
            registrationModel.Address = Entry_Address.Text;
            registrationModel.Province = Entry_Province.Text;
            registrationModel.ZipCode = Entry_Zip_Code.Text;

            UserService _userService = new UserService();
            var updateUserRespond = await _userService.UpdateUser(registrationModel);

            await DisplayAlert("Message", updateUserRespond.Message, "Ok");
        }
    }
}
