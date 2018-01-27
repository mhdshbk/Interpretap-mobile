using Com.OneSignal;
using Com.OneSignal.Abstractions;
using Interpretap.Interfaces;
using Interpretap.Services.Misc;

namespace Interpretap.Services
{
    public class PushNotificationPayloadService : INotificationPayloadService
    {
        const string eventTypeKey = "event_type";
        const string eventKey = "event";
        const string messageKey = "message";

        public event PayloadReceiverEventHandler PayloadReceived;

        public PushNotificationPayloadService()
        {
            OneSignal.Current.StartInit("92c5fd51-a45d-4f27-a22a-c2216f12c95b")
                     .HandleNotificationReceived(OnNotificationReceived)
                     .InFocusDisplaying(OSInFocusDisplayOption.None)
                     .EndInit();
        }

        private void OnNotificationReceived(OSNotification notification)
        {
            var payload = new NotificationPayload();

            var objEventType = new object();
            if (notification.payload.additionalData.TryGetValue(eventTypeKey, out objEventType))
            {
                payload.EventType = objEventType.ToString();
            }

            var objEvent = new object();
            if (notification.payload.additionalData.TryGetValue(eventKey, out objEvent))
            {
                payload.Event = objEvent.ToString();
            }

            var objMessage = new object();
            if (notification.payload.additionalData.TryGetValue(messageKey, out objMessage))
            {
                payload.Message = objMessage.ToString();
            }

            bool payloadCompleted = !string.IsNullOrEmpty(payload.Event) && !string.IsNullOrEmpty(payload.EventType);
            if (payloadCompleted)
            {
                PayloadReceived?.Invoke(this, new PayloadReceivedEventArgs() { Payload = payload });
            }

        }
    }
}
