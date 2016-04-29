using CoreTests.Unit.Support;
using NUnit.Framework;
using Xero.Api.Core.Endpoints;
using Xero.Api.Infrastructure.Http;

namespace CoreTests.Unit.BaseUrlConfiguration.Files
{
    [TestFixture]
    public class FilesUrlConfiguration
    {
        [Test]
        public void it_instructs_its_client_to_ignore_path_segments_on_its_base_url()
        {
            var xeroHttpClient = new XeroHttpClient("http://api.xero.com/api.xero/2.0/", new BlankAuthenticator(), null, null, null, null);

            new FilesEndpoint(xeroHttpClient);

            Assert.AreEqual("http://api.xero.com", xeroHttpClient.BaseUri, "Expected the <XeroHttpClient> to be configured with a new base url");
        }

        [Test]
        public void it_appends_a_path_to_base_uri()
        {
            Assert.AreEqual("/files.xro/1.0/Files", FilesEndpoint.BASE_URI_PATH, 
                "(There is no other practical way to do this)");
        }
    }
}