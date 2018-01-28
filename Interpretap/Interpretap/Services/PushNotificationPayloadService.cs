using System;
using Com.OneSignal;
using Com.OneSignal.Abstractions;
using Interpretap.Interfaces;
using Interpretap.Services.Misc;
using Plugin.LocalNotifications;

namespace Interpretap.Services
{
    public class PushNotificationPayloadService : INotificationPayloadService
    {
        const string eventTypeKey = "event_type";
        const string eventKey = "event";
        const string messageKey = "message";
        const string IsSilentKey = "push_type";
        const string SilentOptionNonSilent = "NON_SILENT";
        const string OneSignalUserId = "92c5fd51-a45d-4f27-a22a-c2216f12c95b";

        public event PayloadReceiverEventHandler PayloadReceived;

        public PushNotificationPayloadService()
        {
            OneSignal.Current.StartInit(OneSignalUserId)
                     .HandleNotificationReceived(OnNotificationReceived)
                     .InFocusDisplaying(OSInFocusDisplayOption.None)
                     .EndInit();
        }

        private void OnNotificationReceived(OSNotification notification)
        {
            HandlePayload(notification);
            HnadleNonSilent(notification);
        }

        private void HnadleNonSilent(OSNotification notification)
        {
            var silentOption = GetPayloadItem(notification, IsSilentKey);
            if (silentOption == SilentOptionNonSilent)
            {
                CrossLocalNotifications.Current.Show("Notification", notification.payload.body);
            }
        }

        private void HandlePayload(OSNotification notification)
        {
            var payload = new NotificationPayload();

            payload.EventType = GetPayloadItem(notification, eventTypeKey);
            payload.Event = GetPayloadItem(notification, eventKey);
            payload.Message = GetPayloadItem(notification, messageKey);

            bool payloadCompleted = !string.IsNullOrEmpty(payload.Event) && !string.IsNullOrEmpty(payload.EventType);
            if (payloadCompleted)
            {
                PayloadReceived?.Invoke(this, new PayloadReceivedEventArgs() { Payload = payload });
            }
        }

        private static string GetPayloadItem(OSNotification notification, string payloadItemKey)
        {
            var obj = new object();
            if (notification.payload.additionalData.TryGetValue(payloadItemKey, out obj))
            {
                return obj.ToString();
            }
            else
            {
                return null;
            }
        }
    }
}
