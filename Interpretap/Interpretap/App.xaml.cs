using Interpretap.ViewModels;
using Xamarin.Forms;
using System.Threading.Tasks;
using Interpretap.Services;
using Interpretap.Models;
using Interpretap.Models.RespondModels;

namespace Interpretap
{
    public partial class App : Application
    {
        public static FetchOpenCallResponce ActiveCallRequest { get; set; }

        public App()
        {
            InitializeComponent();

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

    }
}
