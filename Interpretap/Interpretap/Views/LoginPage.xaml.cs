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

        private async void UserLoginProcedure(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new TabbedPage
            {
                Children =
                {
                    new UserViews.RequestPage(),
                    new UserViews.CallLogPage(),
                    new UserViews.ProfilePage()
                }
            });

        }

        private async void InterpreterLoginProcedure(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new TabbedPage
            {
                Children =
                {
                    new InterpreterViews.CallQueuePage(),
                    new InterpreterViews.CallLogPage(),
                    new InterpreterViews.ProfilePage()
                }
            });
        }

        private void RegistrationProcedure(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }

    }
}
