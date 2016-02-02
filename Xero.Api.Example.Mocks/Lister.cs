using System;
using System.Collections.Generic;
using System.Linq;
using Xero.Api.Core;

namespace Xero.Api.Example.Mocks
{
    internal class Lister
    {
        private readonly IXeroCoreApi _api;

        public Lister(IXeroCoreApi api)
        {
            _api = api;
        }

        public void List()
        {
            Console.WriteLine("Your organisation is called {0}", _api.Organisation.LegalName);

            Console.WriteLine("There are {0} accounts", _api.Accounts.Find().Count());
            Console.WriteLine("There are {0} journal entries", _api.Journals.Find().Count());
            Console.WriteLine("There are {0} Items", _api.Items.Find().Count());

            Console.WriteLine("Done!");
            Console.ReadLine();
        }

        private int GetTotalContactCount()
        {
            int count = _api.Contacts.Find().Count();
            int total = count;
            int page = 2;

            while(count == 100)
            {
                count = _api.Contacts.Page(page++).Find().Count();
                total += count;
            }

            return total;
        }

        private int GetTotalInvoiceCount()
        {
            int count = _api.Invoices.Find().Count();
            int total = count;
            int page = 2;

            while (count == 100)
            {
                count = _api.Invoices.Page(page++).Find().Count();
                total += count;
            }

            return total;
        }

        private void ListReports(IEnumerable<string> reports, string name)
        {
            var enumerable = reports as IList<string> ?? reports.ToList();
            Console.WriteLine("There are {0} {1} reports", enumerable.Count(), name);
                
            if (enumerable.Any())
            {
                Console.WriteLine("Named:");
                foreach (var r in enumerable)
                {
                    Console.WriteLine("\t{0}", r);
                }
            }
        }
    }
}