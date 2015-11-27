﻿using System;
using System.Collections.Generic;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Status;
using Xero.Api.Core.Model.Types;

namespace CoreTests.Integration.Invoices
{
    public abstract class InvoicesTest : ApiWrapperTest
    {
        public Invoice Given_an_draft_invoice(InvoiceType type = InvoiceType.AccountsPayable)
        {
            return Given_an_invoice(type);
        }

        public Invoice Given_an_authorised_invoice(InvoiceType type = InvoiceType.AccountsPayable)
        {
            return Given_an_invoice(type, InvoiceStatus.Authorised);
        }

        public Invoice Given_an_invoice(InvoiceType type = InvoiceType.AccountsPayable, InvoiceStatus status = InvoiceStatus.Draft)
        {
            return Api.Create(new Invoice
            {
                Contact = new Contact { Name = "ABC Bank" },
                Type = type,
                Date = DateTime.UtcNow,
                DueDate = DateTime.UtcNow.AddDays(90),
                LineAmountTypes = LineAmountType.Inclusive,
                Status = status,
				LineItems = new List<LineItem>
                {
                    new LineItem
                    {
                        AccountCode = "200",
                        Description = "Good value item",
                        LineAmount = 100m
                    }
                }
                
            });
        }

        public Invoice Given_a_description_only_invoice(InvoiceType type = InvoiceType.AccountsPayable)
        {
            return Api.Create(new Invoice
            {
                Contact = new Contact { Name = "Richard" },
                Type = type,
				LineItems = new List<LineItem>
                {
                    new LineItem
                    {
                        Description = "This is description only",
                        LineAmount = 100m
                    }
                }
            });
        }
    }
}
