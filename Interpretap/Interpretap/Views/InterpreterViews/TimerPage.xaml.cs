using Interpretap.Common;
using Interpretap.Models;
using Interpretap.Services;
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

        string _callId { get; set; }
        bool _isPaused { get; set; }

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

        public TimerPage(string callId = null)
        {
            _callId = callId;
            InitializeComponent();
        }

        private async Task StartCallProcedureAsync(object sender, EventArgs e)
        {
            var service = new InterpreterService();
            var request = new BaseInterpreterApiRequest();
            request.CallId = _callId;
            await service.StartCall(request);

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

        private async Task TogglePauseCallProcedureAsync(object sender, EventArgs e)
        {
            var service = new InterpreterService();
            var request = new BaseInterpreterApiRequest();
            request.CallId = _callId;

            if (_isPaused)
            {
                // unpausing
                await service.UnpauseCall(request);
                timer.Start();
                ((Button)sender).Text = "Pause";
                BtnEndCall.IsEnabled = true;
            }
            else
            {
                // pausing
                await service.PauseCall(request);
                timer.Stop();
                ((Button)sender).Text = "Unpause";
                BtnEndCall.IsEnabled = false;
            }

            _isPaused = !_isPaused;
        }

        private async Task EndCallProcedureAsync(object sender, EventArgs e)
        {
            var service = new InterpreterService();
            var request = new BaseInterpreterApiRequest();
            request.CallId = _callId;
            await service.EndCall(request);
            timer.Stop();
            CloseTimerPage();
        }

        private void UpdateTimerLabel()
        {
            if (timer == null)
                return;

            if (timer == null)
                return;


            Lbl_Time.Text = timer.GetTimePassed();
        }

        private async Task CancelCallButtonClickedAsync(object sender, EventArgs e)
        {
            var confirmed = await DisplayAlert("Confirmation", "Cancel call?", "Yes", "No");
            if (confirmed)
            {
                var service = new InterpreterService();
                var request = new BaseInterpreterApiRequest();
                request.CallId = _callId;
                await service.CancelCall(request);
                CloseTimerPage();
            }
        }

        private void CloseTimerPage()
        {
            App.ToUpdateLogsFlag = true;
            App.ToUpdateQueueFlag = true;
            Device.BeginInvokeOnMainThread(async () =>
            {
                await App.Current.MainPage.Navigation.PopAsync();
                App.ActivateLogsTab();
            });
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}