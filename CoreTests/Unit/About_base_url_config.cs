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
        public void examples()
        {
            var actual = new SampleXeroApi("https://api.xero.com", new BlankCertificateAuthenticator(), null, null, null, null, null);

            Assert.AreEqual(actual.BaseUri, "https://api.xero.com/api.xro/2.0");
        }

        // TEST: check BOTH ctor paths

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
