using CoreTests.Unit.Support;
using CoreTests.Unit.Support.Lang;
using NUnit.Framework;
using Xero.Api.Infrastructure.Http;
using Xero.Api.Payroll.America.Endpoints;
using Xero.Api.Payroll.Australia.Endpoints;

namespace CoreTests.Unit.BaseUrlConfiguration
{
    [TestFixture]
    public class PayrollUrlConfiguration
    {
        // [i] SuperFundsEndpoint just chosen as an example -- any subclass of `PayrollEndpoint` will do.

        [Test]
        public void each_endpoint_instructs_its_client_to_ignore_path_segments_on_its_base_url()
        {
            var xeroHttpClient = new XeroHttpClient("http://api.xero.com/api.xero/2.0/", new BlankAuthenticator(), null, null, null, null);

            new SuperFundsEndpoint(xeroHttpClient);

            xeroHttpClient.MustHaveBaseUri("http://api.xero.com");
        }

        [Test]
        public void same_goes_for_us_payroll()
        {
            var xeroHttpClient = new XeroHttpClient("http://api.xero.com/api.xero/2.0/", new BlankAuthenticator(), null, null, null, null);

            new WorkLocationsEndpoint(xeroHttpClient);

            xeroHttpClient.MustHaveBaseUri("http://api.xero.com");
        }

        [Test]
        public void it_can_be_anything()
        {
            var xeroHttpClient = new XeroHttpClient("http://any.host.name/xxx/yyy/zzz/", new BlankAuthenticator(), null, null, null, null);

            new SuperFundsEndpoint(xeroHttpClient);

            xeroHttpClient.MustHaveBaseUri("http://any.host.name");
        }

        [Test]
        public void even_a_slash()
        {
            var xeroHttpClient = new XeroHttpClient("http://any.host.name/", new BlankAuthenticator(), null, null, null, null);

            new SuperFundsEndpoint(xeroHttpClient);

            xeroHttpClient.MustHaveBaseUri("http://any.host.name");
        }

        [Test]
        public void or_null()
        {
            var xeroHttpClient = new XeroHttpClient(null, new BlankAuthenticator(), null, null, null, null);

            new SuperFundsEndpoint(xeroHttpClient);

            xeroHttpClient.MustHaveBaseUri(null);
        }

        [Test]
        public void or_empty()
        {
            var xeroHttpClient = new XeroHttpClient(string.Empty, new BlankAuthenticator(), null, null, null, null);

            new SuperFundsEndpoint(xeroHttpClient);

            xeroHttpClient.MustHaveBaseUri(string.Empty);
        }
    }
}