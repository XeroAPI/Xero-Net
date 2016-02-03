using System.Linq;
using Rhino.Mocks;
using System;
using Xero.Api.Core;
using Xero.Api.Core.Endpoints;
using Xero.Api.Core.Model;

namespace Xero.Api.Example.Mocks
{
    class Program
    {
        static void Main(string[] args)
        {
            var api = MockRepository.GenerateStub<IXeroCoreApi>();
            api.Stub(a => a.Organisation).Return(new Organisation() { LegalName = "Mocked Organisation" });


            var accountsEndPoint = MockRepository.GenerateStub<IAccountsEndpoint>();
            accountsEndPoint.Stub(a => a.Find()).Return(Enumerable.Empty<Account>());
            api.Stub(a => a.Accounts).Return(accountsEndPoint);

            var journalsEndpoint = MockRepository.GenerateStub<IJournalsEndpoint>();
            var journal = new Journal()
            {
                Date = DateTime.UtcNow,
            };
            api.Stub(a => a.Journals).Return(journalsEndpoint);
            journalsEndpoint.Stub(a => a.Find()).Return(new[] { journal });


            var itemsEndpoint = MockRepository.GenerateStub<IItemsEndpoint>();
            var item = new Item()
            {
                Code = "MOCK",
                Name = "MOCKED",
                Id = Guid.NewGuid()
            };
            api.Stub(a => a.Items).Return(itemsEndpoint);
            itemsEndpoint.Stub(a => a.Find()).Return(new[] { item, item, item });

            var lister = new Lister(api);
            lister.List();
        }
    }
}
