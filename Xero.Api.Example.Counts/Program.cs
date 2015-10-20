using System;
using Xero.Api.Core;
using Xero.Api.Example.TokenStores;
using Xero.Api.Infrastructure.OAuth;

namespace Xero.Api.Example.Counts
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new ApiUser { Name = Environment.MachineName };
            var tokenStore = new SqliteTokenStore();

            var api = new Applications.Public.Core(tokenStore, user)
            {
                UserAgent = "Xero Api - Listing example"
            };

            new Lister(api).List();            
        }
    }
}
