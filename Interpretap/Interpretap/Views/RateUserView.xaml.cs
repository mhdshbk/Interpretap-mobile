using Interpretap.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Interpretap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RateUserView : ContentPage
    {
        public RateUserView(RateUserViewModel vm)
        {
            InitializeComponent();
            this.BindingContext = vm;
        }
    }
}