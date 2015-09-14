using System;
using Xero.Api.Core.Model;
using Xero.Api.Example.TokenStores;
using Xero.Api.Infrastructure.OAuth;

namespace Xero.Api.Example.Counts
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new ApiUser { Name = Environment.MachineName };
            var tokenStore = new MemoryTokenStore();

            var api = new Applications.Private.Core()
            {
                UserAgent = "Xero Api - Listing example"
            };

            var x = api.ManualJournals.Find("4765d07b-aa03-4e56-9166-50661958c864");

            //var lt = new LinkedTransaction
            //{
            //    SourceTransactionID = Guid.Parse("332d86b2-83b2-464c-9296-bf29caa653f5"),
            //    SourceLineItemID = Guid.Parse("46c70b7e-e34f-417b-bb8f-2d67adaa0b28")
            //};

            //var x = api.LinkedTransactions.Create(lt);


        }
    }
}
