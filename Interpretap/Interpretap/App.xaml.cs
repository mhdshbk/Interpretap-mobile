using System.Threading.Tasks;
using Interpretap.Interfaces;
using Interpretap.Models;
using Interpretap.Models.RespondModels;
using Interpretap.Services;
using Interpretap.ViewModels;
using Xamarin.Forms;

namespace Interpretap
{
    public partial class App : Application
    {
        public static FetchOpenCallResponce ActiveCallRequest { get; set; }
        public static bool ToUpdateLogsFlag { get; set; }
        public static bool ToUpdateQueueFlag { get; set; }
        public static INotificationPayloadService NotificationPayloadService { get; set; }

        public App()
        {
            InitializeComponent();
            InitNotificationService();
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

            if(msg.EventType == "TIMER"){
                if (msg.Event == "CALL_ASSIGN")
                {
                    OpenClientTimerPage();
                }
            }
        }

        private static void InitNotificationService()
        {
            NotificationPayloadService = new PushNotificationPayloadService();
            NotificationPayloadService.PayloadReceived += OnNotificationPayloadReceived;
        }

        public static async Task FetchActiveCallRequestAsync()
        {
            var service = new ClientService();
            var request = new BaseModel();
            var responce = await service.FetchOpenCallRequest(request);
            ActiveCallRequest = responce;
        }

        private void CancelActiveCallRequest()
        {
            var activeCallExists = ActiveCallRequest?.CallId != "0";
            if (activeCallExists)
            {
                var vm = new ActiveCallViewModel() { CallId = ActiveCallRequest.CallId };
                vm.CancelCallCommand.Execute(null);
            }
        }

        public static void ActivateLogsTab()
        {
            var mainNavPage = Current.MainPage as NavigationPage;
            if (mainNavPage == null) return;
            var mainTabbedPage = mainNavPage.CurrentPage as TabbedPage;
            if (mainTabbedPage == null) return;
            var logsTabIndex = 1;
            if (mainTabbedPage.Children.Count < logsTabIndex + 1) return;
            mainTabbedPage.CurrentPage = mainTabbedPage.Children[logsTabIndex];
        }

        public static void OpenClientTimerPage()
        {
            Current.MainPage.Navigation.PushAsync(new Views.UserViews.TimerPage());
        }
    }
}
