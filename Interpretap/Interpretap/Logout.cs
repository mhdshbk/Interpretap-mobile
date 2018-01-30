using Interpretap.Common;
using Interpretap.Models;
using Interpretap.Services;
using Interpretap.Views;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Interpretap
{
    public class Logout
    {
        public async Task LogoutAsync()
        {
            var logoutApiResult = await CallLogoutAPIAsync();
            if (logoutApiResult)
            {
                ClearLoginData();
                DisplayLoginPage();
            }
        }

        private async Task<bool> CallLogoutAPIAsync()
        {
            var userServise = new UserService();
            var logoutRequest = new BaseModel();
            var logoutResponce = await userServise.Logout(logoutRequest);
            var logoutResult = logoutResponce.Status == true;
            return logoutResult;
        }

        void ClearLoginData()
        {
            LocalStorage.LoginResponseLS = null;
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
