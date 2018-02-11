using Interpretap.Common;
using Interpretap.Interfaces;
using Interpretap.Models.RespondModels;
using Interpretap.Services;
using PropertyChanged;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Interpretap.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class UserTimerViewModel
    {
        public event EventHandler TimerDone;

        IAcceptedCallStatusService _callStatusService;
        MyTimer _timer;
        bool _ellipsisAnimationAlive;
        int _ellipsisCount;
        int _maxEllipsisCount = 3;

        FetchCurrentCallResponce ActiveCallRequest => App.ActiveCall.ActiveCallRequest;

        public string CallId { get; set; }
        public string CallStatus { get; set; }

        public string ElapsedTime { get; set; }
        public string Agency { get; private set; }
        public string InterpreterFullName { get; private set; }

        public UserTimerViewModel()
        {
            ElapsedTime = "00:00:00";

            App.ActiveCall.FetchActiveCallRequestAsync();
            App.ActiveCall.PropertyChanged += ActiveCall_PropertyChanged;

            _ellipsisCount = 0;
            _ellipsisAnimationAlive = true;

            _callStatusService = new AcceptedCallStatusService();
            _callStatusService.Started += OnStarted;
            _callStatusService.Paused += OnPaused;
            _callStatusService.Unpaused += OnUnpaused;
            _callStatusService.Stopped += OnStopped;
            _callStatusService.Canceled += OnCanceled;

            _timer = new MyTimer(TimeSpan.FromSeconds(1), () => ElapsedTime = _timer.GetTimePassed());

            var isRecentlyCrashedCall = App.ActiveCall.ActiveCallRequest.CallInfo.DurationInfo != null;
            if (isRecentlyCrashedCall)
            {
                RestorePage();
            }

            AnimateEllipsis();
        }

        private void ActiveCall_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(App.ActiveCall.ActiveCallRequest))
            {
                try
                {
                    Agency = ActiveCallRequest.CallInfo.AgencyInfo.InterpreterBusinessName;
                    var interpreter = ActiveCallRequest.CallInfo.InterpreterInfo;
                    InterpreterFullName = $"{interpreter.InterpreterFirstName} {interpreter.InterpreterLastName}";
                    CallId = ActiveCallRequest.CallInfo.CallDetails.CallReferenceId;
                }
                catch (NullReferenceException)
                {

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        void OnStarted(object sender, EventArgs e)
        {
            _ellipsisAnimationAlive = false;
            CallStatus = "Call active";
            _timer.Start();
        }

        void OnPaused(object sender, EventArgs e)
        {
            _timer.Stop();
            if (_ellipsisAnimationAlive)
            {
                _ellipsisAnimationAlive = false;
            }
            CallStatus = "Call paused";
        }

        void OnUnpaused(object sender, EventArgs e)
        {
            _timer.Start();
            CallStatus = "Call active";
        }

        void OnStopped(object sender, EventArgs e)
        {
            _timer.Stop();
            CallStatus = "Call finished";
            OnTimerDone();
        }

        void OnCanceled(object sender, EventArgs e)
        {
            _ellipsisAnimationAlive = false;
            CallStatus = "Call canceled";
            OnTimerDone();
        }

        void FetchCallInfo()
        {

        }

        async void AnimateEllipsis()
        {
            var callStatusString = "Waiting for interpreter to start call";
            var ellipsisAnimationDelayMillis = 500;
            while (_ellipsisAnimationAlive)
            {
                if (_ellipsisCount == _maxEllipsisCount + 1)
                {
                    _ellipsisCount = 0;
                }
                var ssb = new StringBuilder(callStatusString);
                for (int i = 0; i < _ellipsisCount; i++)
                {
                    ssb.Append(".");
                }
                _ellipsisCount++;
                CallStatus = ssb.ToString();
                await Task.Delay(ellipsisAnimationDelayMillis);
            }
        }

        private void RestorePage()
        {
            var call = App.ActiveCall.ActiveCallRequest.CallInfo;

            var CallLiveStatusId = "3";
            var CallPausedStatusId = "4";

            try
            {
                _timer.SetTimePassed(call.DurationInfo);
                ElapsedTime = _timer.GetTimePassed();
            }
            // call.DurationInfo is invalid 
            catch (ArgumentOutOfRangeException)
            {
                _timer.SetTimePassed("00:00:00");
                ElapsedTime = _timer.GetTimePassed();
            }

            if (call.CallStatusInfo.CallStatusId == CallPausedStatusId)
            {
                OnPaused(this, new EventArgs());
            }
            if (call.CallStatusInfo.CallStatusId == CallLiveStatusId)
            {
                OnStarted(this, new EventArgs());
            }
        }

        private void OnTimerDone()
        {
            App.ToUpdateLogsFlag = true;
            App.ActiveCall.ActiveCallRequest = null;
            TimerDone?.Invoke(this, new EventArgs());
        }
    }
}
