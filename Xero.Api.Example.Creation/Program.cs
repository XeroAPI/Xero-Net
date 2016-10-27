// Comment out the #define ASYNC line to test synchronous operation
#define ASYNC

using System;
using System.Threading.Tasks;
using Xero.Api.Core;
using Xero.Api.Example.TokenStores;
using Xero.Api.Infrastructure.OAuth;

namespace Xero.Api.Example.Creation
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new ApiUser { Name = Environment.MachineName }; // ApiUser is used when retrieving tokens from the token store - See TokenStoreAuthenticator GetToken(IConsumer consumer, IUser user). This is primarily for Partner Applications
            var tokenStore = new SqliteTokenStore();

#if ASYNC
            var api = new Applications.PublicAsync.Core(tokenStore, user)
#else
            var api = new Applications.Public.Core(tokenStore, user)
#endif
            {
                UserAgent = "Xero Api - Creating example"
            };

            var creator = new Creator.Creator();
#if ASYNC
            new Func<Task>(() =>
            {
                return new ApiDataCreation(api).CreateAsync(10, 10,
                    creator.People(5),
                    creator.Addresses(5),
                    creator.Descriptions(5));
            }).StartLongRunningAsync().Unwrap().Wait();
#else
            new ApiDataCreation(api).Create(10, 10,
                creator.People(5),
                creator.Addresses(5),
                creator.Descriptions(5));
#endif
        }
    }
}
