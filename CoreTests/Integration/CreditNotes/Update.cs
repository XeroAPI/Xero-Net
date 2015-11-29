﻿using System.Collections.Generic;
using NUnit.Framework;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Status;

namespace CoreTests.Integration.CreditNotes
{
    [TestFixture]
    public class Update : CreditNotesTest
    {
        [Test]
        public void delete_draft_creditnote()
        {
            const InvoiceStatus expected = InvoiceStatus.Deleted;
            var creditnote = Given_a_creditnote();

            creditnote.Status = expected;

            var status = Api.Update(creditnote).Status;

            Assert.AreEqual(expected, status);
        }

        [Test]
        public void update_creditnote_lineitems()
        {
            var creditnote = Given_a_creditnote();

            var updatedCreditnote = Api.Update(new CreditNote
            {
                Id = creditnote.Id,
                LineItems = new List<LineItem>
                    {
                        new LineItem
                        {
                            Description = creditnote.LineItems[0].Description,
                            Quantity = 2m,
                            UnitAmount = 100m,
                            AccountCode = creditnote.LineItems[0].AccountCode
                        }
                    }
            });

            Assert.AreEqual(100m, updatedCreditnote.LineItems[0].UnitAmount);
            Assert.AreEqual(2m, updatedCreditnote.LineItems[0].Quantity);
            Assert.AreEqual(200m, updatedCreditnote.LineItems[0].LineAmount);
        }
    }
}
