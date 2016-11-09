// Comment out the #define ASYNC line to test synchronous operation
#define ASYNC

using System;
using System.Threading.Tasks;
using Xero.Api.Core;
using Xero.Api.Example.TokenStores;
using Xero.Api.Infrastructure.OAuth;

namespace Xero.Api.Example.Counts
{
    class Program
    {
        static void Main(string[] args)
        {
#if ASYNC
            // Test the Async code, with or without an async IAuthenticator
            new Func<Task>(() => TestAsync(asyncAuthenticator: true)).StartLongRunningAsync().Unwrap().Wait();
#else
            // Test the non-async code
            //Test();
#endif
        }

#if ASYNC
        static async Task TestAsync(bool asyncAuthenticator)
        {
            var user = new ApiUser { Name = Environment.MachineName };
            var tokenStore = new SqliteTokenStore();

            XeroCoreApi api;
            if (asyncAuthenticator)
            {
                api = new Applications.PublicAsync.Core(tokenStore, user) { UserAgent = "Xero Api - Listing example" };
            }
            else
            {
                api = new Applications.Public.Core(tokenStore, user) { UserAgent = "Xero Api - Listing example" };
            }

            await new AsyncLister(api).ListAsync();
        }
#else
        static void Test()
        {
            var user = new ApiUser { Name = Environment.MachineName };
            var tokenStore = new SqliteTokenStore();

            var api = new Applications.Public.Core(tokenStore, user)
            {
                UserAgent = "Xero Api - Listing example"
            };

            new Lister(api).List();
        }
#endif
    }
}
