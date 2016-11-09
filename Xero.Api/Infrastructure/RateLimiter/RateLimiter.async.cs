using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Xero.Api.Infrastructure.RateLimiter
{
    partial class RateLimiter : IAsyncRateLimiter
    {
        static TimeSpan timerPeriodInfinite = TimeSpan.FromMilliseconds(-1);

        public async Task WaitUntilLimitAsync(CancellationToken cancellation)
        {
            while (rateLimiter.Count >= _qty)
            {
                var diff = rateLimiter.Peek().Add(_duration) - DateTime.UtcNow;
                if (diff.TotalMilliseconds > 0)
                {
                    await this.SleepAsync(diff.Add(TimeSpan.FromSeconds(1)), cancellation);
                }

                rateLimiter.Dequeue();
            }

            rateLimiter.Enqueue(DateTime.UtcNow);
        }

        private Task SleepAsync(TimeSpan duration, CancellationToken cancellation)
        {
            var completion = new TaskCompletionSource<bool>();
            var timer = new Timer(
                c =>
                {
                    ((TaskCompletionSource<bool>)c).SetResult(true);
                },
                completion,
                duration,
                timerPeriodInfinite);

            cancellation.Register(timer.Dispose);
            return completion.Task;
        }
    }
}
