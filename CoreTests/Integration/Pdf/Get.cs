using System;
using NUnit.Framework;
using Xero.Api.Core.Model.Types;
using Xero.Api.Infrastructure.Exceptions;

namespace CoreTests.Integration.Pdf
{
    [TestFixture]
    public class Get : ApiWrapperTest
    {
        [Test]
        public void can_get_invoice_as_pdf()
        {
            AssertOk(PdfEndpointType.Invoices, new Invoices.Create().Given_an_invoice().Id);
        }

        [Test]
        public void can_get_credit_note_as_pdf()
        {
            AssertOk(PdfEndpointType.CreditNotes, new CreditNotes.Create().Given_a_creditnote().Id);
        }

        [Test]
        public void invoice_gives_404_when_not_found()
        {
            Assert.Throws<NotFoundException>(() => Api.PdfFiles.Get(PdfEndpointType.Invoices, Guid.NewGuid()));
        }

        [Test]
        public void credit_note_gives_404_when_not_found()
        {
            Assert.Throws<NotFoundException>(() => Api.PdfFiles.Get(PdfEndpointType.CreditNotes, Guid.NewGuid()));
        }

        private void AssertOk(PdfEndpointType type, Guid id)
        {
            var pdf = Api.PdfFiles.Get(type, id);
            var expected = id.ToString("D") + ".pdf";

            Assert.NotNull(pdf);
            Assert.AreEqual(expected, pdf.FileName);
        }
    }    
}
