using System;
using Xero.Api.Example.TokenStores;
using Xero.Api.Infrastructure.OAuth;

namespace Xero.Api.Example.Creation
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new ApiUser { Name = Environment.MachineName };
            var tokenStore = new SqliteTokenStore();

            var api = new Applications.Public.Core(tokenStore, user)
            {
                UserAgent = "Xero Api - Creating example"
            };

            var creator = new Creator.Creator();
            new ApiDataCreation(api).Create(10, 10,
                creator.People(5),
                creator.Addresses(5),
                creator.Descriptions(5));
        }
    }
}
