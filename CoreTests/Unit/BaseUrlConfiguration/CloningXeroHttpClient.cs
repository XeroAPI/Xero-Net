using CoreTests.Unit.Support;
using NUnit.Framework;
using Xero.Api.Infrastructure.Http;

namespace CoreTests.Unit.BaseUrlConfiguration
{
    [TestFixture]
    public class CloningXeroHttpClient
    {
        [Test]
        public void it_produces_new_http_client()
        {
            var original = new XeroHttpClient("http://api.xero.com/a/b/c", new BlankAuthenticator(), null, null, null, null);

            var clone = original.Clone();

            Assert.AreNotSame(clone, original, "Expected the clone to be a new instance");

            clone.TrimBaseUri(); Assert.AreEqual("http://api.xero.com", clone.BaseUri, "Expected the clone to have truncated its base uri");

            Assert.AreEqual("http://api.xero.com/a/b/c" , original.BaseUri, 
                "Expected the original to have preserved its base uri because it shows the clone has operated only on itself.");
        }
    }
}