using System;
using System.Collections.Generic;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Types;

namespace CoreTests.Integration.CreditNotes
{
    public class CreditNotesTest : ApiWrapperTest
    {
        public CreditNote Given_a_creditnote(CreditNoteType type = CreditNoteType.AccountsPayable)
        {
            return Api.CreditNotes.Create(new CreditNote
            {
                Contact = new Contact { Name = "Apple Computers Ltd" },
                Type = type,
                Date = DateTime.UtcNow,
                LineAmountTypes = LineAmountType.Exclusive,
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
