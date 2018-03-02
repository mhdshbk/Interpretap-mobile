using Interpretap.Services.Misc;

namespace Interpretap.Interfaces
{
    public delegate void PayloadReceiverEventHandler(object sender, PayloadReceivedEventArgs e);

    public interface INotificationPayloadService
    {
        event PayloadReceiverEventHandler PayloadReceived;
    }
}
