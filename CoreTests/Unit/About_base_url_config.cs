using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;
using Xero.Api.Common;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.RateLimiter;

namespace CoreTests.Unit
{
    [TestFixture]
    public class About_base_url_config
    {
        [Test]
        public void both_constructors_behave_the_same()
        {
            var constructorOne = new SampleXeroApi("https://api.xero.com", new BlankCertificateAuthenticator(), null, null, null, null, null);
            var constructorTwo = new SampleXeroApi("https://api.xero.com", new BlankAuthenticator(), null, null, null, null, null);

            Assert.AreEqual("https://api.xero.com/api.xro/2.0", constructorOne.BaseUri);
            Assert.AreEqual("https://api.xero.com/api.xro/2.0", constructorTwo.BaseUri);
        }

        [Test]
        public void examples()
        {
            Check(
                Map("https://api.xero.com"                  , "https://api.xero.com/api.xro/2.0"),
                Map(" https://api.xero.com "                , "https://api.xero.com/api.xro/2.0"),
                Map(null                                    , ""),
                Map("HTTPS://API.XERO.COM"                  , "HTTPS://API.XERO.COM/api.xro/2.0"),
                Map("https://api-partner.network.xero.com"  , "https://api-partner.network.xero.com/api.xro/2.0"),
                Map("https://xxx-anything-else-xxx/1.0"     , "https://xxx-anything-else-xxx/1.0"),
                Map("xxx-not-a-url-xxx"                     , "xxx-not-a-url-xxx"));
        }

        // TEST: check ending-with-slash, i.e., https://api.xero.com/
        // TEST: check whitespace

        private static Tuple<string, string> Map(string @from, string to)
        {
            return new Tuple<string, string>(@from, to);
        }

        private void Check(params Tuple<string,string>[] checks)
        {
            foreach (var check in checks)
            {
                var actual = new SampleXeroApi(check.Item1, new BlankCertificateAuthenticator(), null, null, null, null, null);

                Assert.AreEqual(check.Item2, actual.BaseUri);
            }
        }

        class SampleXeroApi : XeroApi
        {
            public SampleXeroApi(
                string baseUri, 
                IAuthenticator auth, 
                IConsumer consumer, 
                IUser user, 
                IJsonObjectMapper readMapper, 
                IXmlObjectMapper writeMapper, 
                IRateLimiter rateLimiter) : base(baseUri, auth, consumer, user, readMapper, writeMapper, rateLimiter)
            {
            }

            public SampleXeroApi(
                string baseUri, 
                ICertificateAuthenticator auth, 
                IConsumer consumer, 
                IUser user, 
                IJsonObjectMapper readMapper, 
                IXmlObjectMapper writeMapper, 
                IRateLimiter rateLimiter) : base(baseUri, auth, consumer, user, readMapper, writeMapper, rateLimiter)
            {
            }
        }
    }

    public class BlankAuthenticator : IAuthenticator
    {
        public void Authenticate(HttpWebRequest request)
        {
        }
    }

    public class BlankCertificateAuthenticator : ICertificateAuthenticator
    {
        public string GetSignature(IConsumer consumer, IUser user, Uri uri, string verb, IConsumer consumer1)
        {
            return "DUMMY";
        }

        public IToken GetToken(IConsumer consumer, IUser user)
        {
            return null;
        }

        public IUser User { get; set; }
        public X509Certificate Certificate { get; private set; }

        public void Authenticate(HttpWebRequest request)
        {
            
        }
    }
}
