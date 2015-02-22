using System;
using System.Collections.Generic;
using System.Linq;
using Xero.Api.Core;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Reports;
using Xero.Api.Core.Model.Types;
using Xero.Api.Example.TokenStores;
using Xero.Api.Infrastructure.OAuth;


namespace Xero.Api.Example.TrackingCategories
{
    class Program
    {
        private static XeroCoreApi api;

        static void Main(string[] args)
        {
            Console.WriteLine("STARTED!!!");

            var user = new ApiUser { Name = Environment.MachineName };
            var tokenStore = new SqliteTokenStore();

            string num = RandomNumberString();

//            api = new Applications.Public.Core(tokenStore, user)
//            {
//                UserAgent = "Xero Api - Phil's Console Tester"
//            };

            Contact contact = CreateContact(num);
            //            CreateInvoice(num);
            //            SearchInvoice(num);
            //            FindContact(num);
            //
            //            AccountCount();

            MakeTransactions(contact);

            Console.WriteLine("FINISHED!!! Press the any key");
            Console.ReadKey();
        }

        private static BankTransaction MakeTransactions(Contact contact)
        {
            Account account = new Account
            {
                //                BankAccountNumber = "1234567890",
                Code = "1234567890"
            };

            BankTransaction bankTransaction = new BankTransaction
            {
                Type = BankTransactionType.Spend,
                Contact = contact,
                Date = DateTime.UtcNow,
                LineItems = GetLineItems(),
                BankAccount = account
            };



            return api.Create(bankTransaction);
        }

        private static IEnumerable<Account> AccountCount()
        {
            IEnumerable<Account> accounts = api.Accounts.Find();

            Console.WriteLine("The number of account is: " + accounts.Count());

            foreach (Account acc in accounts)
            {
                Guid guid = acc.Id;
                Console.WriteLine(acc.Name + " " + acc.BankAccountNumber + " " + acc.Description);

                try
                {
                    Report report = api.Reports.BankStatement(guid, null, null);
                    Console.WriteLine("Closing Balance: " + report.Rows[1].Rows[1].Cells[6].Value);
                }
                catch (Exception e)
                {
                    //                    Console.WriteLine("Caught");
                }
            }

            return accounts;
        }

        private static Invoice CreateInvoice(string num)
        {
            LineItem lineItem = GetLineItem();

            List<LineItem> lineItems = new List<LineItem>();

            lineItems.Add(lineItem);

            Invoice invoice = new Invoice
            {
                Type = InvoiceType.AccountsReceivable,
                Contact = FindContact(num),
                Date = DateTime.UtcNow,
                DueDate = DateTime.UtcNow.AddYears(1),
                LineAmountTypes = LineAmountType.Exclusive,
                Items = lineItems
            };

            return api.Create(invoice);
        }


        private static List<LineItem> GetLineItems()
        {
            List<LineItem> lineItems_ = new List<LineItem>();
            lineItems_.Add(GetLineItem());
            return lineItems_;
        }

        private static LineItem GetLineItem()
        {
            return new LineItem
            {
                Description = "Monthly Batwing rental",
                Quantity = (decimal)4.300,
                UnitAmount = (decimal)395.00,
                AccountCode = "404"
            };
        }


        private static IEnumerable<Invoice> SearchInvoice(string num)
        {
            IEnumerable<Invoice> invoices = api.Invoices
                .ModifiedSince(new DateTime(2011, 1, 31))
                .Page(1)
                .OrderByDescending("DueDate")
                .Find();

            //            IEnumerable<Invoice> invoices = api.Invoices
            //            .ModifiedSince(new DateTime(2011, 1, 31))
            //            .Page(1)
            //            .OrderByDescending("DueDate")
            //            .Find();

            Console.WriteLine("Number of Invoices: " + invoices.Count());

            return invoices;
        }

        private static Contact CreateContact(string num)
        {
            var contact = new Contact
            {
                Name = "Batman " + num,
                FirstName = "Bruce" + num,
                LastName = "Wayne" + num,
                ContactNumber = num
            };

            Console.WriteLine("Contact Created " + num);

            return api.Create(contact);
        }

        private static Contact FindContact(String contactNo)
        {
            Contact contact = api.Contacts.Find(contactNo);

            Console.WriteLine("Contact found: " + contact.FirstName + " " + contact.LastName);

            return contact;
        }

        private static string RandomNumberString()
        {
            Random rand = new Random();
            return rand.Next().ToString();
        }
    }
}
