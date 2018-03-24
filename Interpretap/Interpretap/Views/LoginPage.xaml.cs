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
            //InitForgotPasswordLabel();
        }

        private void InitForgotPasswordLabel()
        {
            //var tgr = new TapGestureRecognizer();
            //tgr.Tapped += (s, e) =>
            //{
                Navigation.PushAsync(new ForgotPasswordPage());
            //};
            //ForgotPasswordLabel.GestureRecognizers.Add(tgr);
        }

        private async Task UserLoginProcedure(object sender, EventArgs e)
        {
            SetActivityIndicatorState(true);
            UserService _userService = new UserService();
            var loginResponse = await _userService.Login(new Models.LoginModel(Entry_Username.Text, Entry_Password.Text, "client"));

            if (!loginResponse.Status)
            {
                await DisplayAlert("Error", loginResponse.GetMessage(), "Ok");
                SetActivityIndicatorState(false);
                return;
            }

            LocalStorage.LoginResponseLS = loginResponse;
            App.User.UserType = Constants.UserTypes.Client;
            App.User.SessionKey = loginResponse.SessionKey;
            LocalStorage.User = App.User;

            var lm = new LoginManager();
            lm.OnLoginSuccessfull();

            App.ActiveCall.FetchActiveCallRequestAsync();

            var page = (new MainPageFactory()).CreateMainPageForClient();
            page.Title = "Interpretap";
            NavigationPage.SetHasNavigationBar(page, true);
            await NavigateAfterSuccessfulLogin(page);

            await lm.OnInterpreterLoginAsync();

            SetActivityIndicatorState(false);
        }

        private async Task InterpreterLoginProcedure(object sender, EventArgs e)
        {
            SetActivityIndicatorState(true);
            UserService _userService = new UserService();
            var loginResponse = await _userService.Login(new Models.LoginModel(Entry_Username.Text, Entry_Password.Text, "interpreter"));

            if (!loginResponse.Status)
            {
                await DisplayAlert("Error", loginResponse.GetMessage(), "Ok");
                SetActivityIndicatorState(false);
                return;
            }

            LocalStorage.LoginResponseLS = loginResponse;
            App.User.UserType = Constants.UserTypes.Interpreter;
            App.User.SessionKey = loginResponse.SessionKey;
            LocalStorage.User = App.User;

            var lm = new LoginManager();
            lm.OnLoginSuccessfull();

            var page = (new MainPageFactory()).CreateMainPageForInterpreter();
            page.Title = "Interpretap";
            await NavigateAfterSuccessfulLogin(page);

            await lm.OnInterpreterLoginAsync();
            SetActivityIndicatorState(false);
        }

        private async Task NavigateAfterSuccessfulLogin(Page navigateTo)
        {
            NavigationPage.SetHasNavigationBar(navigateTo, true);

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
            }
            else
            {
                Entry_Password.IsPassword = true;
            }
        }

        private void SetActivityIndicatorState(bool enable)
        {
            if (enable)
            {
                ActivityIndicator.IsVisible = true;
                MainLayout.IsVisible = false;
            }
            else
            {
                ActivityIndicator.IsVisible = false;
                MainLayout.IsVisible = true;
            }
        }
    }
}