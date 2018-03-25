using Interpretap.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Interpretap.Views.UserViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RequestPage : ContentPage
    {
        RequestViewModel _ViewModel;
        public RequestPage()
        {
            InitializeComponent();
            _ViewModel = new RequestViewModel();
            
            this.BindingContext = _ViewModel;
            ActiveCallView.BindingContext = _ViewModel.ActiveCallViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _ViewModel.OnAppearingAsync();
        }
    }
}
