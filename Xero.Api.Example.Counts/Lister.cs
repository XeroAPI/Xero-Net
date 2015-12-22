using System;
using System.Collections.Generic;
using System.Linq;
using Xero.Api.Core;

namespace Xero.Api.Example.Counts
{
    internal class Lister
    {
        private readonly XeroCoreApi _api;

        public Lister(XeroCoreApi api)
        {
            _api = api;
        }

        public void List()
        {
            Console.WriteLine("Your organisation is called {0}", _api.Organisation.LegalName);

            Console.WriteLine("There are {0} accounts", _api.Accounts.Find().Count());
            Console.WriteLine("There are {0} bank transactions", _api.BankTransactions.Find().Count());
            Console.WriteLine("There are {0} bank transfers", _api.BankTransfers.Find().Count());
            Console.WriteLine("There are {0} branding themes", _api.BrandingThemes.Find().Count());
            Console.WriteLine("There are {0} contacts", GetTotalContactCount());
            Console.WriteLine("There are {0} credit notes", _api.CreditNotes.Find().Count());
            Console.WriteLine("There are {0} currencies", _api.Currencies.Find().Count());
            Console.WriteLine("There are {0} employees", _api.Employees.Find().Count());
            Console.WriteLine("There are {0} expense claims", _api.ExpenseClaims.Find().Count());
            Console.WriteLine("There are {0} defined items", _api.Items.Find().Count());
            Console.WriteLine("There are {0} invoices", GetTotalInvoiceCount());
            Console.WriteLine("There are {0} journal entries", _api.Journals.Find().Count());
            Console.WriteLine("There are {0} manual journal entries", _api.ManualJournals.Find().Count());
            Console.WriteLine("There are {0} payments", _api.Payments.Find().Count());
            Console.WriteLine("There are {0} receipts", _api.Receipts.Find().Count());
            Console.WriteLine("There are {0} repeating invoices", _api.RepeatingInvoices.Find().Count());
            Console.WriteLine("There are {0} tax rates", _api.TaxRates.Find().Count());
            Console.WriteLine("There are {0} tracking categories", _api.TrackingCategories.Find().Count());
            Console.WriteLine("There are {0} users", _api.Users.Find().Count());

            
            ListReports(_api.Reports.Named, "named");
            ListReports(_api.Reports.Published, "published");

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