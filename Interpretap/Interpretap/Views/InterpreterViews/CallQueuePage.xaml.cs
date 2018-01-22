using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Interpretap.Models;
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
                    _viewModel.QueueCalls.Clear();
                    _viewModel.LoadData().GetAwaiter();
                    App.ToUpdateQueueFlag = false;
                }
            }

            

            firstTime = false;
        }

    }
}
