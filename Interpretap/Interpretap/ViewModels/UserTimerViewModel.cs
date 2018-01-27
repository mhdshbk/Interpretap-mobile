using System;
using System.Text;
using System.Threading.Tasks;
using Interpretap.Common;
using Interpretap.Interfaces;
using Interpretap.Models.RespondModels;
using Interpretap.Services;
using PropertyChanged;

namespace Interpretap.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class UserTimerViewModel
    {
        IAcceptedCallStatusService _callStatusService;
        MyTimer _timer;
        bool _ellipsisAnimationAlive;
        int _ellipsisCount;
        int _maxEllipsisCount = 3;

        FetchOpenCallResponce ActiveCallRequest => App.ActiveCallRequest;

        public string CallId => ActiveCallRequest.CallId;
        public string CallStatus { get; set; }

        public string ElapsedTime { get; set; }

        public UserTimerViewModel()
        {
            ElapsedTime = "00:00:00";

            _ellipsisCount = 0;
            _ellipsisAnimationAlive = true;

            _callStatusService = new AcceptedCallStatusService();
            _callStatusService.Started += OnStarted;
            _callStatusService.Paused += OnPaused;
            _callStatusService.Unpaused += OnUnpaused;
            _callStatusService.Stopped += OnStopped;

            _timer = new MyTimer(TimeSpan.FromSeconds(1), () => ElapsedTime = _timer.GetTimePassed());

            AnimateEllipsis();
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

        //private async Task CloseTimerPage()
        //{
        //    App.ToUpdateLogsFlag = true;
        //    App.ToUpdateQueueFlag = true;
        //    await Navigation.PopAsync();
        //    App.ActivateLogsTab();
        //}
    }
}
