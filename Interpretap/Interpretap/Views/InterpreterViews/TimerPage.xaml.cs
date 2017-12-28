using Interpretap.Common;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Interpretap.Views.InterpreterViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimerPage : ContentPage
    {
        private bool _timerActive = false;
        private MyTimer timer;

        private void SetTimerActive(bool activeStatus)
        {
            _timerActive = activeStatus;

            if (_timerActive)
            {
                StartCallsStack.IsVisible = false;
                EndCallStack.IsVisible = true;
            }
            else
            {
                StartCallsStack.IsVisible = true;
                EndCallStack.IsVisible = false;
            }
        }

        public TimerPage()
        {
            InitializeComponent();
        }

        private void StartCallProcedure(object sender, EventArgs e)
        {
            SetTimerActive(true);

            if (timer == null) {
                timer = new MyTimer(TimeSpan.FromSeconds(1), UpdateTimerLabel);
                timer.Start();
            } else
            {
                timer.Stop();
                timer.Start();
            }
        }

        private void PauseCallProcedure(object sender, EventArgs e)
        {
            SetTimerActive(false);
            timer.Stop();
        }

        private void EndCallProcedure(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void UpdateTimerLabel()
        {
            if (timer == null)
                return;

            if (timer == null)
                return;


            Lbl_Time.Text = timer.GetTimePassed();
        }
    }
}