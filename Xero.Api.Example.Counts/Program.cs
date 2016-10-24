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
            // Test the non-async code
            //Test();

            // Test the Async code
            new Func<Task>(() => TestAsync(asyncAuthenticator: true)).StartLongRunningAsync().Unwrap().Wait();
        }

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

        static async Task TestAsync(bool asyncAuthenticator)
        {
            Console.WriteLine("Starting test...");

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

            //new Lister(api).List();

            Console.WriteLine("Test complete...");
        }
    }
}
