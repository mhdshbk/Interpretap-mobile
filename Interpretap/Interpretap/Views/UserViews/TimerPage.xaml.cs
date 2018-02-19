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
            this.BindingContext = _VM;
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}