﻿using Interpretap.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Interpretap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RequestPasswordResetCodePage : ContentPage
    {
        public RequestPasswordResetCodePage()
        {
            InitializeComponent();
            this.BindingContext = new RequestPasswordResetCodeViewModel();
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
	}
}