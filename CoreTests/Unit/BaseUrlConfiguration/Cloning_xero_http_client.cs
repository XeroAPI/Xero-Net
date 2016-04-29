using CoreTests.Unit.Support;
using NUnit.Framework;
using Xero.Api.Infrastructure.Http;

namespace CoreTests.Unit.BaseUrlConfiguration
{
    [TestFixture]
    public class Cloning_xero_http_client
    {
        [Test]
        public void it_produces_new_http_client()
        {
            var original = new XeroHttpClient("http://api.xero.com/a/b/c", new BlankAuthenticator(), null, null, null, null);

            var clone = original.Clone();

            Assert.AreNotSame(clone, original);

            clone.TrimBaseUri();

            Assert.AreEqual("http://api.xero.com"       , clone.BaseUri);
            Assert.AreEqual("http://api.xero.com/a/b/c" , original.BaseUri);
        }
    }
}