using Interpretap.Common;
using Interpretap.Core;
using Interpretap.Models;
using Interpretap.Models.RespondModels;
using Interpretap.Services;
using Interpretap.ViewModels;
using PropertyChanged;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Interpretap.Views.InterpreterViews
{
    [AddINotifyPropertyChangedInterface]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimerPage : ContentPage
    {
        private string CallLiveStatusId = "3";
        private string CallPausedStatusId = "4";

        private bool _timerActive = false;
        private bool _timerStarted = false;
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

            MessagingCenter.Subscribe<App>(this, Constants.Strings.AppResumed, async (o) => await OnAppResumedAsync(o));
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
                _timerStarted = true;
            }
            else
            {
                timer.Stop();
                timer.Start();
                _timerStarted = true;
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
                _timerStarted = true;
                ((Image)sender).Source = "pause.png";
                //((Button)sender).Text = "Pause";
                BtnEndCall.IsEnabled = true;
            }
            else
            {
                // pausing
                await service.PauseCall(request);
                timer.Stop();
                _timerStarted = false;
                ((Image)sender).Source = "play.png";
                //((Button)sender).Text = "Unpause";
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
            _timerStarted = false;
            CloseTimerPage();
            RateInterpreterAsync();
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
            MessagingCenter.Unsubscribe<App>(this, Constants.Strings.AppResumed);
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
                BtnTogglePause.Source = "play.png"; // I don't proud of this
            }
            if (call.CallStatusInfo.CallStatusId == CallLiveStatusId)
            {
                SetTimerActive(true);
                RestoreTimerForCall(call);

                if (!_timerStarted)
                {
                    timer.Start();
                    _timerStarted = true;
                }
                BtnTogglePause.Source = "pause.png"; // I don't proud of this
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

        private async Task RateInterpreterAsync()
        {
            var rateModel = new RateUserModel(ClientId, ActiveCallRequest.CallId);
            var rateViewModel = new RateUserViewModel(rateModel);
            var ratePage = new RateUserView(rateViewModel);
            Device.BeginInvokeOnMainThread(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(ratePage);
            });
        }

        private async Task OnAppResumedAsync(App obj)
        {
            await App.ActiveCall.FetchActiveCallRequestAsync();
            RestoreCrashedCall();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}