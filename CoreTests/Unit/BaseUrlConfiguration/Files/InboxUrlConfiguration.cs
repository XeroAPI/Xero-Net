using CoreTests.Unit.Support;
using NUnit.Framework;
using Xero.Api.Core.Endpoints;
using Xero.Api.Infrastructure.Http;

namespace CoreTests.Unit.BaseUrlConfiguration.Files
{
    [TestFixture]
    public class InboxUrlConfiguration
    {
        [Test]
        public void it_instructs_its_client_to_ignore_path_segments_on_its_base_url()
        {
            var xeroHttpClient = new XeroHttpClient("http://api.xero.com/api.xero/2.0/", new BlankAuthenticator(), null, null, null, null);

            new InboxEndpoint(xeroHttpClient);

            Assert.AreEqual("http://api.xero.com", xeroHttpClient.BaseUri, "Expected the <XeroHttpClient> to be configured with a new base url");
        }
    }
}