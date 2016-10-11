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
        public Task WaitUntilLimitAsync(CancellationToken cancellation)
        {
            // TODO: Proper rate limiting check
            var completion = new TaskCompletionSource<bool>();
            var timer = new Timer(
                c =>
                {
                    ((TaskCompletionSource<bool>)c).SetResult(true);
                },
                completion,
                1000,
                0);

            cancellation.Register(timer.Dispose);
            return completion.Task;
        }
    }
}
