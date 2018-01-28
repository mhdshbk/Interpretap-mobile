using System;

namespace Interpretap.Interfaces
{
    interface ICallQueueService
    {
        event EventHandler CallRequested;
    }
}
