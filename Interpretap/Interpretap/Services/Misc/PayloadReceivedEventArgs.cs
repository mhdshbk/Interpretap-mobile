using System;

namespace Interpretap.Services.Misc
{
    public class PayloadReceivedEventArgs : EventArgs
    {
        public NotificationPayload Payload { get; set; }
    }
}
