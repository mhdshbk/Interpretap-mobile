using Interpretap.Common;
using Interpretap.Models;
using Interpretap.Models.RespondModels;
using Interpretap.Services;
using Interpretap.Views;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Interpretap
{
    public class LoginManager 
    {
        public void OnLoginSuccessfull()
        {
            App.InitNotificationService();
        }

        public async Task LogoutAsync()
        {
            var logoutApiResult = await CallLogoutAPIAsync();
            var logoutSuccess = logoutApiResult.Status == true;
            if (logoutSuccess)
            {
                ClearUserData();
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Error", logoutApiResult.Message, "OK");
            }
        }

        public void ClearUserData()
        {
            ClearLoginData();
            DisplayLoginPage();
        }

        public async Task OnClientLoginAsync()
        {
            await App.ActiveCall.FetchActiveCallRequestAsync();
            if (App.ActiveCall.ActiveCallExist)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new Views.UserViews.TimerPage());
            }
        }

        public async Task OnInterpreterLoginAsync()
        {
            await App.ActiveCall.FetchActiveCallRequestAsync();
            if (App.ActiveCall.ActiveCallExist)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new Views.InterpreterViews.TimerPage(App.ActiveCall.ActiveCallRequest.CallId));
            }
        }

        private async Task<BaseRespond> CallLogoutAPIAsync()
        {
            var userServise = new UserService();
            var logoutRequest = new BaseModel();
            var logoutResponce = await userServise.Logout(logoutRequest);
            return logoutResponce;
        }

        void ClearLoginData()
        {
            LocalStorage.LoginResponseLS = null;
            LocalStorage.User = null;
        }

        private void ClearNavigationStack()
        {
            var navigation = App.Current.MainPage.Navigation;
            var pages = navigation.NavigationStack.ToList();
            foreach (var page in pages)
            {
                navigation.RemovePage(page);
            }
        }

        private void DisplayLoginPage()
        {
            App.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}
