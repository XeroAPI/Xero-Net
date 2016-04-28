using CoreTests.Unit.Support;
using NUnit.Framework;
using Xero.Api.Infrastructure.Http;
using Xero.Api.Payroll.Australia.Endpoints;

namespace CoreTests.Unit.BaseUrlConfiguration
{
    [TestFixture]
    public class PayrollUrlConfiguration
    {
        // [i] SuperFundsEndpoint just chosen as an example -- subclass of `PayrollEndpoint` will do

        [Test]
        public void each_endpoint_instructs_its_client_to_ignore_path_segments_on_is_base_url()
        {
            var xeroHttpClient = new XeroHttpClient("http://api.xero.com/api.xero/2.0/", new BlankAuthenticator(), null, null, null, null);

            new SuperFundsEndpoint(xeroHttpClient);

            Assert.AreEqual("http://api.xero.com", xeroHttpClient.BaseUri, "Expected the <XeroHttpClient> to be configured with a new base url");
        }

        [Test]
        public void it_can_be_anything()
        {
            var xeroHttpClient = new XeroHttpClient("http://any.host.name/xxx/yyy/zzz/", new BlankAuthenticator(), null, null, null, null);

            new SuperFundsEndpoint(xeroHttpClient);

            Assert.AreEqual("http://any.host.name", xeroHttpClient.BaseUri, "Expected the <XeroHttpClient> to be configured with a new base url");
        }

        [Test]
        public void even_a_slash()
        {
            var xeroHttpClient = new XeroHttpClient("http://any.host.name/", new BlankAuthenticator(), null, null, null, null);

            new SuperFundsEndpoint(xeroHttpClient);

            Assert.AreEqual("http://any.host.name", xeroHttpClient.BaseUri, "Expected the <XeroHttpClient> to be configured with a new base url");
        }
    }
}