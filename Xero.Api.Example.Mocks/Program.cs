using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xero.Api.Core;
using Xero.Api.Core.Endpoints;
using Xero.Api.Core.Model;
using Xero.Api.Example.Counts;

namespace Xero.Api.Example.Mocks
{
    class Program
    {
        static void Main(string[] args)
        {
            var api = MockRepository.GenerateStub<IXeroCoreApi>();
            IJournalsEndpoint journals = MockRepository.GenerateStub<IJournalsEndpoint>();
            var journal = new Journal()
            {
                Date = DateTime.UtcNow,
            };

            api.Stub(a => a.Organisation).Return(new Organisation() { LegalName = "Mocked Organisation" });

            //var accountsEndPoint = MockRepository.GenerateStub<AccountsEndpoint>();
            //accountsEndPoint.Stub(a => a.Find()).Return(Enumerable.Empty<Account>());
            //api.Stub(a => a.Accounts).Return(accountsEndPoint);

            api.Stub(a => a.Journals).Return(journals);
            journals.Stub(a => a.Find()).Return(new[] { journal });

            Lister l = new Lister(api);
            l.List();
        }
    }
}
