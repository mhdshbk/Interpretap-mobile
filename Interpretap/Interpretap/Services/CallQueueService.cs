using Interpretap.Interfaces;
using System;

namespace Interpretap.Services
{
    public class CallQueueService : ICallQueueService
    {
        INotificationPayloadService NotificationPayloadService = App.NotificationPayloadService;

        public event EventHandler CallRequested;

        public CallQueueService()
        {
            NotificationPayloadService.PayloadReceived += NotificationPayloadService_PayloadReceived;
        }

        private void NotificationPayloadService_PayloadReceived(object sender, Misc.PayloadReceivedEventArgs e)
        {
            var msg = e.Payload;
            if (msg.EventType == "CALL")
            {
                if (msg.Event == "OPEN_CALL")
                {
                    CallRequested?.Invoke(this, new EventArgs());
                }
            }
        }
    }
}
