using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Interpretap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            LoginRequestSpinner.IsVisible = false;
            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
        }

        private void UserLoginProcedure(object sender, EventArgs e)
        {
            DisplayAlert("User", "Login Success.", "Ok");
        }

        private void InterpreterLoginProcedure(object sender, EventArgs e)
        {
            DisplayAlert("Interpreter", "Login Success.", "Ok");
        }

        private void RegistrationProcedure(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }

    }
}
