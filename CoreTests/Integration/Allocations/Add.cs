using System;
using System.Linq;
using CoreTests.Integration.Invoices;
using NUnit.Framework;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Types;

namespace CoreTests.Integration.Allocations
{
    [TestFixture]
    public class Add : ApiWrapperTest
    {
        [Test]
        public void allocation_to_invoice()
        {
            var creditNote = new CreditNotes.CreditNotesTest().Given_an_authorised_creditnote(CreditNoteType.AccountsReceivable);
            var invoice = new Create().Given_an_authorised_invoice(InvoiceType.AccountsReceivable);
            var expected = Math.Min(creditNote.Total, invoice.Total.GetValueOrDefault());

            var result = Api.Allocations.Add(new Allocation
                {
                    AppliedAmount = expected,
                    CreditNote = creditNote,
                    Invoice = invoice
                });

            Assert.AreEqual(expected, result.Amount);
            Assert.AreEqual(invoice.Id, result.Invoice.Id);
            Assert.AreEqual(creditNote.Id, result.CreditNote.Id);
        }

        [Test]
        public void allocation_to_invoice_minimal()
        {            
            var creditNote = new CreditNotes.CreditNotesTest().Given_an_authorised_creditnote();
            var invoice = new Create().Given_an_authorised_invoice();
            var expected = Math.Min(creditNote.Total, invoice.Total.GetValueOrDefault());

            var result = Api.Allocations.Add(new Allocation
            {
                AppliedAmount = expected,
                CreditNote = new CreditNote { Id = creditNote.Id },
                Invoice = new Invoice { Id = invoice.Id }
            });

            Assert.AreEqual(expected, result.Amount);
            Assert.AreEqual(invoice.Id, result.Invoice.Id);
            Assert.AreEqual(creditNote.Id, result.CreditNote.Id);
        }


        [Test]
        public void allocation_on_creditnote()
        {
            var creditNote = new CreditNotes.CreditNotesTest().Given_an_authorised_creditnote();
            var invoice = new Create().Given_an_authorised_invoice();
            var expected = Math.Min(creditNote.Total, invoice.Total.GetValueOrDefault());

            Api.Allocations.Add(new Allocation
            {
                AppliedAmount = expected,
                CreditNote = new CreditNote { Id = creditNote.Id },
                Invoice = new Invoice { Id = invoice.Id }
            });

            creditNote = Api.CreditNotes.Find(creditNote.Id);
            
            Assert.AreEqual(1, creditNote.Allocations.Count);
            Assert.AreEqual(expected, creditNote.Allocations.First().Amount);
        }
    }
}
