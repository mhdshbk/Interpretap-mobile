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
    }
}