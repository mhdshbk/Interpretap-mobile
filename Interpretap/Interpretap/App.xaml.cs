using Interpretap.Core;
using Interpretap.Interfaces;
using Interpretap.Services;
using System.Threading.Tasks;
using Xamarin.Forms;
using System;

namespace Interpretap
{
    public partial class App : Application
    {
        public static bool ToUpdateLogsFlag { get; set; }
        public static bool ToUpdateQueueFlag { get; set; }
        public static INotificationPayloadService NotificationPayloadService { get; set; }
        public static ActiveCallModel ActiveCall { get; set; }
        public static UserModel User { get; set; }

        public App()
        {
            InitializeComponent();
            InitNotificationService();
            InitActiveCall();
            InitUser();
            MainPage = new NavigationPage(new Interpretap.Views.LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            //CancelActiveCallRequest(); // TODO: manage so that call to be cancelled if the app really being closed
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        static void OnNotificationPayloadReceived(object sender, Services.Misc.PayloadReceivedEventArgs e)
        {
            var msg = e.Payload;

            if (msg.EventType == "TIMER")
            {
                if (msg.Event == "CALL_ASSIGN")
                {
                    OpenClientTimerPage();
                }
            }
            if (msg.EventType == "CALL")
            {
                if (msg.Event == "OPEN_CALL")
                {
                    ActivateQueueTab();
                }
            }
        }

        private static void InitNotificationService()
        {
            NotificationPayloadService = new PushNotificationPayloadService();
            NotificationPayloadService.PayloadReceived += OnNotificationPayloadReceived;
        }

        private static void InitActiveCall()
        {
            ActiveCall = new ActiveCallModel();
            //ActiveCall.FetchActiveCallRequestAsync();
        }

        private void InitUser()
        {
            User = new UserModel();
        }

        public static void ActivateLogsTab()
        {
            ActivateMainPageTab(1);
        }

        private static void OpenClientTimerPage()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Current.MainPage.Navigation.PushAsync(new Views.UserViews.TimerPage());
            });
        }

        private static void ActivateQueueTab()
        {
            ActivateMainPageTab(0);
        }

        private static void ActivateMainPageTab(int tabIndex)
        {
            var mainNavPage = Current.MainPage as NavigationPage;
            if (mainNavPage == null) return;
            var mainTabbedPage = mainNavPage.CurrentPage as TabbedPage;
            if (mainTabbedPage == null) return;
            if (mainTabbedPage.Children.Count < tabIndex + 1) return;
            Device.BeginInvokeOnMainThread(() => { mainTabbedPage.CurrentPage = mainTabbedPage.Children[tabIndex]; });
        }

        public static async Task LogoutAsync()
        {
            var logout = new Logout();
            await logout.LogoutAsync();
        }
    }
}
