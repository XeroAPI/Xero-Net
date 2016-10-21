using System;
using System.Threading.Tasks;

namespace Xero.Api.Core
{
    public static class TaskExtensions
    {
        public static Task<T> StartLongRunningAsync<T>(this Func<T> task)
        {
            return Task.Factory.StartNew<T>(task, TaskCreationOptions.LongRunning);
        }

        public static Task StartLongRunningAsync(this Action task)
        {
            return Task.Factory.StartNew(task, TaskCreationOptions.LongRunning);
        }
    }
}
