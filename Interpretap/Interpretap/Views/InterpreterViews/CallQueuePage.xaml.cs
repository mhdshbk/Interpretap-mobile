﻿using Interpretap.Models;
using Interpretap.Services;
using Interpretap.ViewModels;
using Xamarin.Forms;

namespace Interpretap.Views.InterpreterViews
{
    public partial class CallQueuePage : ContentPage
    {
        private bool firstTime = true; //Xamarin bug workaround
        private CallQueueViewModel _viewModel { get; set; }

        public CallQueuePage()
        {
            InitializeComponent();

            _viewModel = new CallQueueViewModel();
            BindingContext = _viewModel;

            listView.ItemsSource = _viewModel.QueueCalls;

            listView.ItemSelected += (sender, e) => {
                ((ListView)sender).SelectedItem = null;
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (firstTime)
            {
                if (_viewModel.QueueCalls.Count == 0)
                    _viewModel.LoadData().GetAwaiter();
           }
            else
            {
                if (App.ToUpdateQueueFlag)
                {
                    _viewModel.ReloadData().GetAwaiter();
                    App.ToUpdateQueueFlag = false;
                }
            }

            firstTime = false;
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var request = new BaseInterpreterApiRequest()
            {
                CallId = EntryCallId.Text
            };
            var service = new InterpreterService();
            service.CancelCall(request);
        }
    }
}
