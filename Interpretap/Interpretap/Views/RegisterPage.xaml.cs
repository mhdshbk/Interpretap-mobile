using System;
using System.Collections.Generic;
using static Interpretap.Common.Constants;
using Xamarin.Forms;

namespace Interpretap.Views
{
    public partial class RegisterPage : ContentPage
    {

        public RegisterPage()
        {
            InitializeComponent();
            Entry_Password.Completed += (s, e) => Entry_Password_Confirm.Focus();
            Entry_Password_Confirm.Completed += (s, e) => Entry_First_Name.Focus();
            Entry_First_Name.Completed += (s, e) => Entry_Last_Name.Focus();
            Entry_Last_Name.Completed += (s, e) => Entry_Email.Focus();
            Entry_Email.Completed += (s, e) => Entry_Phone_Number.Focus();
            Entry_Phone_Number.Completed += (s, e) => Entry_Address.Focus();
            Entry_Address.Completed += (s, e) => Entry_City.Focus();
            Entry_City.Completed += (s, e) => Entry_Province.Focus();
            Entry_Province.Completed += (s, e) => Entry_Zip_Code.Focus();
            Entry_Zip_Code.Completed += (s, e) => RegisterProcedure(s, e);

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
            };
        }

        private void RegisterProcedure(object sender, EventArgs e)
        {
            DisplayAlert("Registered", "Registration Completed.", "Ok");
        }
    }
}
