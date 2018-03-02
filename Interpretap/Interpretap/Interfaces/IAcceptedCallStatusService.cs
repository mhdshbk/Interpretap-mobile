using System;
namespace Interpretap.Interfaces
{
    public interface IAcceptedCallStatusService
    {
        event EventHandler Started;
        event EventHandler Paused;
        event EventHandler Unpaused;
        event EventHandler Stopped;
        event EventHandler Canceled;
    }
}
