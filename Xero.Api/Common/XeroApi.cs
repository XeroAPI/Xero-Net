using Xero.Api.Infrastructure.Http;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.RateLimiter;

namespace Xero.Api.Common
{
    // It is used to plug together the the components which are used for authentication and serialization.
    public abstract class XeroApi
    {
        public string BaseUri { get; protected set; }

        protected XeroHttpClientAccounting AccountingClient { get; private set; }
        protected XeroHttpClientFiles FilesClient { get; private set; }
        protected XeroHttpClientPayroll PayrollClient { get; private set; }

        private XeroApi(string baseUri)
        {
            BaseUri = baseUri;
        }

        protected XeroApi(string baseUri, IAuthenticator auth, IConsumer consumer, IUser user, IJsonObjectMapper readMapper, IXmlObjectMapper writeMapper, IRateLimiter rateLimiter)
            : this(baseUri)
        {
            AccountingClient = new XeroHttpClientAccounting(BaseUri, auth, consumer, user, readMapper, writeMapper, rateLimiter);
            FilesClient = new XeroHttpClientFiles(BaseUri, auth, consumer, user, readMapper, writeMapper, rateLimiter);
            PayrollClient = new XeroHttpClientPayroll(BaseUri, auth, consumer, user, readMapper, writeMapper, rateLimiter);
        }

        protected XeroApi(string baseUri, ICertificateAuthenticator auth, IConsumer consumer, IUser user, IJsonObjectMapper readMapper, IXmlObjectMapper writeMapper, IRateLimiter rateLimiter)
            : this(baseUri)
        {
            AccountingClient = new XeroHttpClientAccounting(BaseUri, auth, consumer, user, readMapper, writeMapper, rateLimiter);
            FilesClient = new XeroHttpClientFiles(BaseUri, auth, consumer, user, readMapper, writeMapper, rateLimiter);
            PayrollClient = new XeroHttpClientPayroll(BaseUri, auth, consumer, user, readMapper, writeMapper, rateLimiter);
        }

        public string UserAgent
        {
            get
            {
                return AccountingClient.UserAgent;
            }
            set
            {
                AccountingClient.UserAgent = value;
            }
        }        
    }
}