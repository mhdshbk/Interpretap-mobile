using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Interpretap.Views.InterpreterViews
{
    public partial class CallQueuePage : ContentPage
    {
        public ICommand AcceptCallCommand { get; private set; }

        public CallQueuePage()
        {
            InitializeComponent();
            ObservableCollection<QueueCall> queueCalls = new ObservableCollection<QueueCall>
            {
                new QueueCall{ Name = "Ippo Makunouchi"},
                new QueueCall{ Name = "Haris Botic"}
            };

            listView.ItemsSource = queueCalls;

            listView.ItemSelected += (sender, e) => {
                ((ListView)sender).SelectedItem = null;
            };
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
