using Xero.Api.Infrastructure.Http;
using Xero.Api.Infrastructure.Interfaces;

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

        protected XeroApi(string baseUri, IAuthenticator auth, IConsumer consumer, IUser user, IJsonObjectMapper readMapper, IXmlObjectMapper writeMapper)
            : this(baseUri)
        {
            Client = new XeroHttpClient(baseUri, auth, consumer, user, readMapper, writeMapper);
        }

        protected XeroApi(string baseUri, ICertificateAuthenticator auth, IConsumer consumer, IUser user, IJsonObjectMapper readMapper, IXmlObjectMapper writeMapper)
            : this(baseUri)
        {
            Client = new XeroHttpClient(baseUri, auth, consumer, user, readMapper, writeMapper);
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