using System;
using System.Collections.Generic;
using static Interpretap.Common.Constants;
using Xamarin.Forms;
using Interpretap.Models;
using System.Threading.Tasks;
using Interpretap.Services;
using Xamarin.Forms.Xaml;

namespace Interpretap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            Entry_Registration_Key.Completed += (s, e) => Entry_Username.Focus();
            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => Entry_Password_Confirm.Focus();
            Entry_Password_Confirm.Completed += (s, e) => Entry_First_Name.Focus();
            Entry_First_Name.Completed += (s, e) => Entry_Last_Name.Focus();
            Entry_Last_Name.Completed += (s, e) => GenderPicker.Focus();
            GenderPicker.SelectedIndexChanged += (s,e) => Entry_Email.Focus();
            Entry_Email.Completed += (s, e) => Entry_Phone_Number.Focus();
            Entry_Phone_Number.Completed += (s, e) => Entry_Address.Focus();
            Entry_Address.Completed += (s, e) => Entry_City.Focus();
            Entry_City.Completed += (s, e) => Entry_Province.Focus();
            Entry_Province.Completed += (s, e) => Entry_Zip_Code.Focus();

            foreach (String profileTypeName in ProfileTypes.Keys)
                ProfileTypePicker.Items.Add(profileTypeName);

            ProfileTypePicker.SelectedIndexChanged += (sender, args) =>
            {
                if (ProfileTypePicker.SelectedIndex == -1)
                {
                    return;
                }
                else
                {
                    string profileTypeName = ProfileTypePicker.Items[ProfileTypePicker.SelectedIndex];
                    string profileTypeId = ProfileTypes[profileTypeName];
                    Lbl_Registration_Key.IsVisible = profileTypeId.Equals("interpreter") ? true : false;
                    Entry_Registration_Key.IsVisible = profileTypeId.Equals("interpreter") ? true : false;
                }

                foreach (String genderName in Genders.Keys)
                    GenderPicker.Items.Add(genderName);
            };
        }

        private async Task RegisterProcedure(object sender, EventArgs e)
        {
            var registrationModel = new RegisterModel();
            registrationModel.InterpreterTerpcode = Entry_Registration_Key.Text;
            registrationModel.Username = Entry_Username.Text;
            registrationModel.Password = Entry_Password.Text;
            registrationModel.PasswordConfirmation = Entry_Password_Confirm.Text;
            registrationModel.FirstName = Entry_First_Name.Text;
            registrationModel.LastName = Entry_Last_Name.Text;
            registrationModel.GenderId = Genders[GenderPicker.Items[GenderPicker.SelectedIndex]];
            registrationModel.Email = Entry_Email.Text;
            registrationModel.PhoneNumber = Entry_Phone_Number.Text;
            registrationModel.City = Entry_City.Text;
            registrationModel.Address = Entry_Address.Text;
            registrationModel.Province = Entry_Province.Text;
            registrationModel.ZipCode = Entry_Zip_Code.Text;
            registrationModel.UserType = ProfileTypePicker.SelectedItem.ToString().ToLower();

            var r = new Random();
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    registrationModel.DeviceId = r.Next(1000000);
                    registrationModel.DeviceType = 1;
                    break;
                case Device.Android:
                    registrationModel.DeviceId = r.Next(1000000);
                    registrationModel.DeviceType = 2;
                    break;
            }

            UserService _userService = new UserService();
            var insertUserResponse = await _userService.InsertUser(registrationModel);

            await DisplayAlert("Message", insertUserResponse.Message, "Ok");
        }
    }
}
