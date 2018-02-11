using Interpretap.Common;
using Interpretap.Models;
using Interpretap.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Interpretap.Models.RespondModels;
using PropertyChanged;

namespace Interpretap.Views.InterpreterViews
{
    [AddINotifyPropertyChangedInterface]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimerPage : ContentPage
    {
        private string CallLiveStatusId = "3";
        private string CallPausedStatusId = "4";

        private bool _timerActive = false;
        private MyTimer timer;

        string _callId { get; set; }
        bool _isPaused { get; set; }

        public string ClientCompany { get; set; }
        public string ClientId { get; set; }
        public string ClientFullName { get; set; }
        public string CallRefId { get; set; }
        public string ClientPhone { get; set; }

        FetchCurrentCallResponce ActiveCallRequest => App.ActiveCall.ActiveCallRequest;

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
            App.ActiveCall.FetchActiveCallRequestAsync();

            _callId = callId;
            InitializeComponent();
            this.BindingContext = this;

            App.ActiveCall.PropertyChanged += ActiveCall_PropertyChanged;

            var isRecentlyCrashedCall = App.ActiveCall.ActiveCallRequest.CallId == callId;
            if (isRecentlyCrashedCall)
            {
                RestoreCrashedCall();
            }
        }

        private void ActiveCall_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(App.ActiveCall.ActiveCallRequest))
            {
                try
                {
                    ClientCompany = ActiveCallRequest.CallInfo.ClientBusinessInfo.BusinessName;
                    ClientId = ActiveCallRequest.CallInfo.ClientInfo.UserId;
                    ClientFullName = $"{ActiveCallRequest.CallInfo.ClientInfo.FirstName} {ActiveCallRequest.CallInfo.ClientInfo.LastName}";
                    CallRefId = ActiveCallRequest.CallInfo.CallDetails.CallReferenceId;
                    ClientPhone = ActiveCallRequest.CallInfo.ClientInfo.PhoneNumber;
                }
                catch (Exception ex)
                {

                }
            }
        }

        private async Task StartCallProcedureAsync(object sender, EventArgs e)
        {
            var service = new InterpreterService();
            var request = new BaseInterpreterApiRequest();
            request.CallId = _callId;
            await service.StartCall(request);

            SetTimerActive(true);

            if (timer == null)
            {
                timer = new MyTimer(TimeSpan.FromSeconds(1), UpdateTimerLabel);
                timer.Start();
            }
            else
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
            if (timer == null) return;

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

        private void RestoreCrashedCall()
        {
            var call = App.ActiveCall.ActiveCallRequest.CallInfo;

            if (call.CallStatusInfo.CallStatusId == CallPausedStatusId)
            {
                SetTimerActive(true);
                RestoreTimerForCall(call);

                _isPaused = true;
                BtnTogglePause.Text = "Unpause"; // I don't proud of this
            }
            if (call.CallStatusInfo.CallStatusId == CallLiveStatusId)
            {
                SetTimerActive(true);
                RestoreTimerForCall(call);

                timer.Start();
                BtnTogglePause.Text = "Pause"; // I don't proud of this
            }

        }

        private void RestoreTimerForCall(Models.RespondModels.CallInfo call)
        {
            if (timer == null)
            {
                timer = new MyTimer(TimeSpan.FromSeconds(1), UpdateTimerLabel);
            }
            try
            {
                timer.SetTimePassed(call.DurationInfo);
                UpdateTimerLabel();
            }
            // call.DurationInfo is invalid 
            catch (ArgumentOutOfRangeException)
            {
                timer.SetTimePassed("00:00:00");
                UpdateTimerLabel();
            }
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private void CrashButton_Clicked(object sender, EventArgs e)
        {
            App.Crash();
        }
    }
}