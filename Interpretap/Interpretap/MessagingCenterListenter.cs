using Interpretap.Common;
using Interpretap.Services;
using Xamarin.Forms;

namespace Interpretap
{
    public class MessagingCenterListenter
    {
        public MessagingCenterListenter()
        {
            MessagingCenter.Subscribe<ResponceContentStatusChecker>(this, Constants.Strings.SessionFailed, OnSessionKeyInvalidMessageAsync);
        }

        private void OnSessionKeyInvalidMessageAsync(ResponceContentStatusChecker obj)
        {
            var logout = new LoginManager();
            logout.ClearUserData();
            App.Current.MainPage.DisplayAlert("Warning", "User's session has ended", "OK");
        }
    }
}
