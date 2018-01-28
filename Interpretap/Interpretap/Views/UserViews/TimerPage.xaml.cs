using Interpretap.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Interpretap.Views.UserViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimerPage : ContentPage
    {
        public UserTimerViewModel _VM;
        public TimerPage()
        {
            InitializeComponent();

            _VM = new UserTimerViewModel();
            _VM.TimerDone += (s, e) => { OnTimerDone(s, e); };
            this.BindingContext = _VM;
        }

        private void OnTimerDone(object sender, System.EventArgs e)
        {
            CloseTimerPage();
        }

        private void CloseTimerPage()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await App.Current.MainPage.Navigation.PopAsync();
                App.ActivateLogsTab();
            });
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}