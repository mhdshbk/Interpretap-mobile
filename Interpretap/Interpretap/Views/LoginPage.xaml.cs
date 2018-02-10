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
            SetActivityIndicatorState(false);
            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
        }

        private async Task UserLoginProcedure(object sender, EventArgs e)
        {
            SetActivityIndicatorState(true);
            UserService _userService = new UserService();
            var loginResponse = await _userService.Login(new Models.LoginModel(Entry_Username.Text, Entry_Password.Text, "client"));

            if (!loginResponse.Status)
            {
                await DisplayAlert("Error", loginResponse.Message, "Ok");
                SetActivityIndicatorState(false);
                return;
            }

            LocalStorage.LoginResponseLS = loginResponse;
            App.User.UserType = Constants.UserTypes.Client;

            var lm = new LoginManager();
            lm.OnLoginSuccessfull();

            App.ActiveCall.FetchActiveCallRequestAsync();

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

            page.Children.Add(new ProfilePage());
            await NavigateAfterSuccessfulLogin(page);
            SetActivityIndicatorState(false);
        }

        private async Task InterpreterLoginProcedure(object sender, EventArgs e)
        {
            SetActivityIndicatorState(true);
            UserService _userService = new UserService();
            var loginResponse = await _userService.Login(new Models.LoginModel(Entry_Username.Text, Entry_Password.Text, "interpreter"));

            if (!loginResponse.Status)
            {
                await DisplayAlert("Error", loginResponse.Message, "Ok");
                SetActivityIndicatorState(false);
                return;
            }

            LocalStorage.LoginResponseLS = loginResponse;
            App.User.UserType = Constants.UserTypes.Interpreter;

            var lm = new LoginManager();
            lm.OnLoginSuccessfull();

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

            page.Children.Add(new ProfilePage());
            await NavigateAfterSuccessfulLogin(page);
            await App.ActiveCall.FetchActiveCallRequestAsync();
            if (App.ActiveCall.ActiveCallExist)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new Views.InterpreterViews.TimerPage(App.ActiveCall.ActiveCallRequest.CallId));
            }
            SetActivityIndicatorState(false);
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

        private void TogglePasswordButtonClicked(object sender, EventArgs e)
        {
            var passwordHidden = Entry_Password.IsPassword;
            if (passwordHidden)
            {
                Entry_Password.IsPassword = false;
                BtnShowPassword.Text = "Hide";
            }
            else
            {
                Entry_Password.IsPassword = true;
                BtnShowPassword.Text = "Show";
            }
        }

        private void SetActivityIndicatorState(bool enable)
        {
            if (enable)
            {
                ActivityIndicator.IsVisible = true;
                ControlsStack.IsVisible = false;
            }
            else
            {
                ActivityIndicator.IsVisible = false;
                ControlsStack.IsVisible = true;
            }
        }
    }
}