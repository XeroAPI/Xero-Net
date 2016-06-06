using NUnit.Framework;
using Xero.Api.Core.Model.Status;
using Xero.Api.Core.Model.Types;

namespace CoreTests.Integration.Invoices
{
    [TestFixture]
    public class OnlineInvoiceUrl : InvoicesTest
    {

        [Test]
        public void find_the_online_invoice_url_for_an_accrec_invoice()
        {
            var invoice = Given_an_invoice(InvoiceType.AccountsReceivable, InvoiceStatus.Authorised);

            var onlineInvoiceUrl = Api.Invoices.RetrieveOnlineInvoiceUrl(invoice.Id);

            Assert.True(!string.IsNullOrEmpty(onlineInvoiceUrl.OnlineInvoiceUrl));
        }
    }
}
