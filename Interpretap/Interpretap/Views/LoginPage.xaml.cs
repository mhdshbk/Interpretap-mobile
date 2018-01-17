using Interpretap.Common;
using Interpretap.Services;
using System;
using System.Linq;
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
            UserService _userService = new UserService();
            var loginResponse = await _userService.Login(new Models.LoginModel(Entry_Username.Text, Entry_Password.Text, "client"));

            if (!loginResponse.Status)
            {
                await DisplayAlert("Error", loginResponse.Message, "Ok");
                return;
            }

            LocalStorage.LoginResponseLS = loginResponse;

            var page = new TabbedPage
            {
                Children =
                {
                    new UserViews.RequestPage(),
                    new UserViews.CallLogPage()
                }
            };

            if (loginResponse.UserInfo.IsManager)
                page.Children.Add(new UserViews.BusinessesPage());


            page.Children.Add(new UserViews.ProfilePage());
            await NavigateAfterSuccessfulLogin(page);
        }

        private async Task InterpreterLoginProcedure(object sender, EventArgs e)
        {
            UserService _userService = new UserService();
            var loginResponse = await _userService.Login(new Models.LoginModel(Entry_Username.Text, Entry_Password.Text, "interpreter"));

            if (!loginResponse.Status)
            {
                await DisplayAlert("Error", loginResponse.Message, "Ok");
                return;
            }

            LocalStorage.LoginResponseLS = loginResponse;
            //var loginResponse = LocalStorage.LoginResponseLS;

            var page = new TabbedPage
            {
                Children =
                {
                    new InterpreterViews.CallQueuePage(),
                    new InterpreterViews.CallLogPage()
                }
            };

            if (loginResponse.UserInfo.IsManager)
                page.Children.Add(new InterpreterViews.AgenciesPage());
            if(true)
            page.Children.Add(new InterpreterViews.ProfilePage());
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