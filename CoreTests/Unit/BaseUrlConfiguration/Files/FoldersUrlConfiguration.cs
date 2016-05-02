using CoreTests.Unit.Support;
using CoreTests.Unit.Support.Lang;
using NUnit.Framework;
using Xero.Api.Core.Endpoints;
using Xero.Api.Infrastructure.Http;

namespace CoreTests.Unit.BaseUrlConfiguration.Files
{
    [TestFixture]
    public class FoldersUrlConfiguration
    {
        [Test]
        public void it_instructs_its_client_to_ignore_path_segments_on_its_base_url()
        {
            var xeroHttpClient = new XeroHttpClient("http://api.xero.com/api.xero/2.0/", new BlankAuthenticator(), null, null, null, null);

            new FoldersEndpoint(xeroHttpClient);

            xeroHttpClient.MustHaveBaseUri("http://api.xero.com");
        }
    }
}