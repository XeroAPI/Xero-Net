using Xero.Api.Infrastructure.Http;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.RateLimiter;

namespace Xero.Api.Common
{
    // It is used to plug together the the components which are used for authentication and serialization.
    public abstract class XeroApi
    {
        public string BaseUri { get; protected set; }

        protected XeroHttpClient Client { get; private set; }

        private XeroApi(string baseUri)
        {
            BaseUri = baseUri;
        }

        protected XeroApi(string baseUri, IAuthenticator auth, IConsumer consumer, IUser user, IJsonObjectMapper readMapper, IXmlObjectMapper writeMapper, IRateLimiter rateLimiter)
            : this(baseUri)
        {
            Client = new XeroHttpClient(baseUri, auth, consumer, user, readMapper, writeMapper, rateLimiter);
        }

        protected XeroApi(string baseUri, ICertificateAuthenticator auth, IConsumer consumer, IUser user, IJsonObjectMapper readMapper, IXmlObjectMapper writeMapper, IRateLimiter rateLimiter)
            : this(Calculate(baseUri))
        {
            Client = new XeroHttpClient(BaseUri, auth, consumer, user, readMapper, writeMapper, rateLimiter);
        }

        private static string Calculate(string baseUri)
        {
            return baseUri.Equals("https://api.xero.com") ? string.Format("{0}/api.xro/2.0", baseUri) : baseUri;
        }

        public string UserAgent
        {
            get
            {
                return Client.UserAgent;
            }
            set
            {
                Client.UserAgent = value;
            }
        }        
    }
}