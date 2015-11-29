﻿using System;
using System.Collections.Generic;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Status;
using Xero.Api.Core.Model.Types;

namespace CoreTests.Integration.CreditNotes
{
    public class CreditNotesTest : ApiWrapperTest
    {
        public CreditNote Given_an_authorised_creditnote(CreditNoteType type = CreditNoteType.AccountsPayable)
        {
            return Given_a_creditnote(type: type, status: InvoiceStatus.Authorised);
        }

        public CreditNote Given_a_draft_creditnote(CreditNoteType type = CreditNoteType.AccountsPayable)
        {
            return Given_a_creditnote(type: type);
        }

        public CreditNote Given_a_creditnote(string contactName = "Apple Computers Ltd", CreditNoteType type = CreditNoteType.AccountsPayable, InvoiceStatus status = InvoiceStatus.Draft)
        {
            return Api.CreditNotes.Create(new CreditNote
            {
                Contact = new Contact { Name = contactName },
                Type = type,
                Date = DateTime.UtcNow,
                LineAmountTypes = LineAmountType.Exclusive,
                Status = status,
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
        }
    }
}
