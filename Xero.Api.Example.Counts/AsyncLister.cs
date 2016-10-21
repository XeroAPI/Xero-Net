using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xero.Api.Core;

namespace Xero.Api.Example.Counts
{
    partial class AsyncLister
    {
        private readonly IXeroCoreApi _api;

        public AsyncLister(IXeroCoreApi api)
        {
            _api = api;
        }

        public async Task ListAsync()
        {
            Console.WriteLine("Your organisation is called {0}", (await _api.GetOrganisationAsync()).LegalName);

            Console.WriteLine("There are {0} accounts", (await _api.Accounts.FindAsync()).Count());
            Console.WriteLine("There are {0} bank transactions", (await _api.BankTransactions.FindAsync()).Count());
            Console.WriteLine("There are {0} bank transfers", (await _api.BankTransfers.FindAsync()).Count());
            Console.WriteLine("There are {0} branding themes", (await _api.BrandingThemes.FindAsync()).Count());
            Console.WriteLine("There are {0} contacts", await GetTotalContactCountAsync());
            Console.WriteLine("There are {0} credit notes", (await _api.CreditNotes.FindAsync()).Count());
            Console.WriteLine("There are {0} currencies", (await _api.Currencies.FindAsync()).Count());
            Console.WriteLine("There are {0} employees", (await _api.Employees.FindAsync()).Count());
            Console.WriteLine("There are {0} expense claims", (await _api.ExpenseClaims.FindAsync()).Count());
            Console.WriteLine("There are {0} defined items", (await _api.Items.FindAsync()).Count());
            Console.WriteLine("There are {0} invoices", await GetTotalInvoiceCountAsync());
            Console.WriteLine("There are {0} journal entries", (await _api.Journals.FindAsync()).Count());
            Console.WriteLine("There are {0} manual journal entries", (await _api.ManualJournals.FindAsync()).Count());
            Console.WriteLine("There are {0} payments", (await _api.Payments.FindAsync()).Count());
            Console.WriteLine("There are {0} receipts", (await _api.Receipts.FindAsync()).Count());
            Console.WriteLine("There are {0} repeating invoices", (await _api.RepeatingInvoices.FindAsync()).Count());
            Console.WriteLine("There are {0} tax rates", (await _api.TaxRates.FindAsync()).Count());
            //Console.WriteLine("There are {0} tracking categories", (await _api.TrackingCategories.FindAsync()).Count());
            Console.WriteLine("There are {0} users", (await _api.Users.FindAsync()).Count());


            //ListReports(_api.Reports.Named, "named");
            //ListReports(_api.Reports.Published, "published");

            Console.WriteLine("Done! Press any key to exit.");
            Console.ReadKey();
        }

        private async Task<int> GetTotalContactCountAsync()
        {
            int count = (await _api.Contacts.FindAsync()).Count();
            int total = count;
            int page = 2;

            while (count == 100)
            {
                count = (await _api.Contacts.Page(page++).FindAsync()).Count();
                total += count;
            }

            return total;
        }

        private async Task<int> GetTotalInvoiceCountAsync()
        {
            int count = (await _api.Invoices.FindAsync()).Count();
            int total = count;
            int page = 2;

            while (count == 100)
            {
                count = (await _api.Invoices.Page(page++).FindAsync()).Count();
                total += count;
            }

            return total;
        }
    }
}
