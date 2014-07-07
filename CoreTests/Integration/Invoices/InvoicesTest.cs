using System;
using System.Collections.Generic;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Types;

namespace CoreTests.Integration.Invoices
{
    public abstract class InvoicesTest : ApiWrapperTest
    {
        public Invoice Given_an_invoice()
        {
            return Api.Create(new Invoice
            {
                Contact = new Contact { Name = "ABC Limited" },
                Type = InvoiceType.AccountsReceivable,
                Date = DateTime.UtcNow,
                DueDate = DateTime.UtcNow.AddDays(90),
                LineAmountTypes = LineAmountType.Inclusive,
                Items = new List<LineItem>
                {
                    new LineItem
                    {
                        AccountCode = "200",
                        Description = "Good value item",
                        LineAmount = 25.6m
                    }
                }
            });
        }

        public Invoice Given_a_description_only_invoice(InvoiceType type)
        {
            return Api.Create(new Invoice
            {
                Contact = new Contact { Name = "Richard" },
                Type = type,
                Items = new List<LineItem>
                {
                    new LineItem
                    {
                        Description = "This is description only",
                        LineAmount = 23.6m
                    }
                }
            });
        }
    }
}
