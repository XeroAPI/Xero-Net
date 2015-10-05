using System;
using System.Collections.Generic;
using Xero.Api.Common;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Status;
using Xero.Api.Core.Model.Types;
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

            var cN = api.CreditNotes.Update(new CreditNote
            {
                Contact = new Contact { Name = "abc" },
                Number = "cnhelpsd",
                Type = CreditNoteType.AccountsPayable,
                Date = DateTime.UtcNow,
                LineAmountTypes = LineAmountType.Exclusive,
                Status = InvoiceStatus.Draft,
                LineItems = new List<LineItem>
                {
                    new LineItem
                    {
                        AccountCode = "720",
                        Description = "MacBook - White",
                        UnitAmount = 1995.00m
                    }
                }
            });

            //var inv = api.Invoices.Create(new Invoice
            //{
            //    Contact = new Contact { Name = "ABC Bank" },
            //    Type = InvoiceType.AccountsPayable,
            //    Date = DateTime.UtcNow,
            //    DueDate = DateTime.UtcNow.AddDays(90),
            //    LineAmountTypes = LineAmountType.Inclusive,
            //    Status = InvoiceStatus.Draft,
            //    LineItems = new List<LineItem>
            //    {
            //        new LineItem
            //        {
            //            AccountCode = "200",
            //            Description = "Good value item",
            //            LineAmount = 100m
            //        },
            //        new LineItem
            //        {
            //            AccountCode = "200",
            //            Description = "Good value item",
            //            LineAmount = 100m
            //        }
            //    }

            //});


            //var lt = new LinkedTransaction
            //{
            //    SourceTransactionID = inv.Id,
            //    SourceLineItemID = inv.LineItems[0].LineItemId
            //};

            //var x = api.LinkedTransactions.Create(lt);

            //x.SourceLineItemID = inv.LineItems[1].LineItemId;

            //var updated = api.LinkedTransactions.Update(x);

            //var get = api.LinkedTransactions.Find(x.Id);
        }
    }
}
