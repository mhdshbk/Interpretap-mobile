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
        public ICommand AcceptCallCommand { get; private set; }

        private CallQueueViewModel _viewModel { get; set; }

        public CallQueuePage()
        {
            InitializeComponent();

            _viewModel = new CallQueueViewModel();
            BindingContext = _viewModel;

            ObservableCollection<OpenCallModel> queueCalls = new ObservableCollection<OpenCallModel>{};

            listView.ItemsSource = queueCalls;

            listView.ItemSelected += (sender, e) => {
                ((ListView)sender).SelectedItem = null;
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.LoadData().GetAwaiter();
        }

        public class QueueCall
        {
            public String Name { get; set; }

            public ICommand StartTimerCommand
            {
                get
                {
                    return new Command((e) =>
                    {
                        Application.Current.MainPage.Navigation.PushAsync(new InterpreterViews.TimerPage());
                    });
                }
            }
        }

    }
}
