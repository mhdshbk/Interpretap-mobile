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

        private async Task UserLoginProcedure(object sender, EventArgs e)
        {
            Page page = new TabbedPage
            {
                Children =
                {
                    new UserViews.RequestPage(),
                    new UserViews.CallLogPage(),
                    new UserViews.ProfilePage()
                }
            };

            await NavigateAfterSuccessfulLogin(page);
        }

        private async Task InterpreterLoginProcedure(object sender, EventArgs e)
        {
            Page page = new TabbedPage
            {
                Children =
                {
                    new InterpreterViews.CallQueuePage(),
                    new InterpreterViews.CallLogPage(),
                    new InterpreterViews.ProfilePage()
                }
            };

            await NavigateAfterSuccessfulLogin(page);
        }

        private async Task NavigateAfterSuccessfulLogin(Page navigateTo)
        {
            NavigationPage.SetHasNavigationBar(navigateTo, false);

            Navigation.InsertPageBefore(navigateTo, Navigation.NavigationStack.First());
            await Navigation.PopToRootAsync();
        }

        private async Task RegistrationProcedure(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

    }
}
