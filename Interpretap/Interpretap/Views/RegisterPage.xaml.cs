using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Interpretap.Views
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            Entry_Password.Completed += (s, e) => Entry_First_Name.Focus();
            Entry_First_Name.Completed += (s, e) => Entry_Last_Name.Focus();
            Entry_Last_Name.Completed += (s, e) => Entry_Email.Focus();
            Entry_Email.Completed += (s, e) => Entry_Phone_Number.Focus();
            Entry_Phone_Number.Completed += (s, e) => Entry_Address.Focus();
            Entry_Address.Completed += (s, e) => Entry_City.Focus();
            Entry_City.Completed += (s, e) => Entry_Province.Focus();
            Entry_Province.Completed += (s, e) => Entry_Zip_Code.Focus();
            Entry_Zip_Code.Completed += (s, e) => RegisterProcedure(s, e);
        }

        private void RegisterProcedure(object sender, EventArgs e)
        {
            DisplayAlert("Registered", "Registration Completed.", "Ok");
        }
    }
}
