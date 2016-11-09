using System;
using System.Threading;
using System.Threading.Tasks;

namespace Xero.Api.Core
{
    public static class TaskExtensions
    {
        public static Task<T> StartLongRunningAsync<T>(this Func<T> task, CancellationToken cancellation = default(CancellationToken))
        {
            return Task.Factory.StartNew<T>(task, cancellation, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }

        public static Task StartLongRunningAsync(this Action task, CancellationToken cancellation = default(CancellationToken))
        {
            return Task.Factory.StartNew(task, cancellation, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }
    }
}
