using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Interpretap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPasswordPage : ContentPage
    {
        public ForgotPasswordPage()
        {
            InitializeComponent();
        }
		protected override void OnAppearing()
		{
            base.OnAppearing();
            if (Device.RuntimePlatform == Device.iOS)
            {
                ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#f37a3f");
                ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.White;
            }
		}

		protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (Device.RuntimePlatform == Device.iOS)
            {
                ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.White;
                ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.Black;
            }
        }

        private void TgrGetCode_Tapped(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new RequestPasswordResetCodePage());
        }

        private void TgrReset_Tapped(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new ResetPasswordPage());
        }
    }
}