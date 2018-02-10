using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Interpretap.Common
{
    public class MyTimer
    {
        private readonly TimeSpan timespan;
        private readonly Action callback;
        private TimeSpan timePassed;

        private CancellationTokenSource cancellation;

        public MyTimer(TimeSpan timespan, Action callback)
        {
            this.timespan = timespan;            
            this.callback = callback;
            this.timePassed = TimeSpan.Zero;

            this.cancellation = new CancellationTokenSource();
        }

        public void Start()
        {
            CancellationTokenSource cts = this.cancellation;
            Device.StartTimer(this.timespan,
                () => {
                    if (cts.IsCancellationRequested) return false;
                    timePassed = timePassed.Add(TimeSpan.FromTicks(timespan.Ticks));
                    callback.Invoke();
                    return true;
            });
        }

        public void Stop()
        {
            Interlocked.Exchange(ref this.cancellation, new CancellationTokenSource()).Cancel();
        }
            
        public String GetTimePassed()
        {
            return new DateTime(this.timePassed.Ticks).ToString("HH:mm:ss");
        }

        public void SetTimePassed(TimeSpan timePassed)
        {
            this.timePassed = timePassed;
        }
    }
}
