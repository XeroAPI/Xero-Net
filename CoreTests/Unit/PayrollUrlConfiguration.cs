using NUnit.Framework;
using Xero.Api.Infrastructure.Http;
using Xero.Api.Payroll.Australia.Endpoints;

namespace CoreTests.Unit
{
    [TestFixture]
    public class PayrollUrlConfiguration
    {
        [Test]
        public void each_endpoint_instructs_its_client_to_ignore_path_segments_on_is_base_url()
        {
            var xeroHttpClient = new XeroHttpClient("http://api.xero.com/api.xero/2.0/", new BlankAuthenticator(), null, null, null, null);

            new SuperFundsEndpoint(xeroHttpClient);

            Assert.AreEqual("http://api.xero.com", xeroHttpClient.BaseUri, "Expected the <XeroHttpClient> to be configured with a new base url");
        }
    }
}