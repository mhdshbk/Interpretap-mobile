﻿using System;
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