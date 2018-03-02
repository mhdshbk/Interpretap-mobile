using System;
using Interpretap.Interfaces;

namespace Interpretap.Services
{
    public class AcceptedCallStatusService : IAcceptedCallStatusService
    {
        INotificationPayloadService _notificationPayloadService;

        public event EventHandler Started;
        public event EventHandler Paused;
        public event EventHandler Unpaused;
        public event EventHandler Stopped;
        public event EventHandler Canceled;

        public AcceptedCallStatusService()
        {
            _notificationPayloadService = App.NotificationPayloadService;
            _notificationPayloadService.PayloadReceived += OnPayloadReceived;
        }

        void OnPayloadReceived(object sender, Misc.PayloadReceivedEventArgs e)
        {
            var msg = e.Payload;

            if (msg.EventType == "TIMER")
            {
                if (msg.Event == "CALL_START")
                {
                    Started?.Invoke(this, new EventArgs());
                }
                if (msg.Event == "CALL_START_PAUSE")
                {
                    Paused?.Invoke(this, new EventArgs());
                }
                if (msg.Event == "CALL_END_PAUSE")
                {
                    Unpaused?.Invoke(this, new EventArgs());
                }
                if (msg.Event == "CALL_END")
                {
                    Stopped?.Invoke(this, new EventArgs());
                }
                if (msg.Event == "CALL_CANCEL")
                {
                    Canceled?.Invoke(this, new EventArgs());
                }
            }
        }
    }
}
