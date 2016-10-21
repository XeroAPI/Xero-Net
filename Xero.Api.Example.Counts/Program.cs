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
            //Test();

            var test = Task.Factory.StartNew(() => TestAsync(), TaskCreationOptions.LongRunning);
            test.Unwrap().Wait();
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

        static async Task TestAsync()
        {
            Console.WriteLine("Starting test...");

            var user = new ApiUser { Name = Environment.MachineName };
            var tokenStore = new SqliteTokenStore();

            var api = new Applications.PublicAsync.Core(tokenStore, user)
            {
                UserAgent = "Xero Api - Listing example"
            };

            //new Lister(api).List();
            await new AsyncLister(api).ListAsync();

            Console.WriteLine("Test complete...");
        }
    }
}
