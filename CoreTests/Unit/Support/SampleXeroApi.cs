using Xero.Api.Common;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.RateLimiter;

namespace CoreTests.Unit.Support
{
    public class SampleXeroApi : XeroApi
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