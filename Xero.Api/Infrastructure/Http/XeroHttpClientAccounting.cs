using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.RateLimiter;

namespace Xero.Api.Infrastructure.Http
{
    // This makes the calls to the web as text and asks the object mappers to convert to and from objects to text.
    // This knows nothing about the types being passed to and fro. (Except for the constraint in the generic type)
    public class XeroHttpClientAccounting : XeroHttpClient, IXeroHttpClient
    {
        private static string apiType = "/api.xro/2.0";

        public XeroHttpClientAccounting(string baseUri, IAuthenticator auth, IConsumer consumer, IUser user, IJsonObjectMapper jsonMapper, IXmlObjectMapper xmlMapper)
            : base(CalculateUrl(baseUri, apiType), auth, consumer, user, jsonMapper, xmlMapper)
        {
        }

        public XeroHttpClientAccounting(string baseUri, IAuthenticator auth, IConsumer consumer, IUser user, IJsonObjectMapper jsonMapper, IXmlObjectMapper xmlMapper, IRateLimiter rateLimiter)
            : base(CalculateUrl(baseUri, apiType), auth, consumer, user, jsonMapper, xmlMapper, rateLimiter)
        {
        }

        public XeroHttpClientAccounting(string baseUri, ICertificateAuthenticator auth, IConsumer consumer, IUser user, IJsonObjectMapper jsonMapper, IXmlObjectMapper xmlMapper)
            : base(CalculateUrl(baseUri, apiType), auth, consumer, user, jsonMapper, xmlMapper)
        {
        }

        public XeroHttpClientAccounting(string baseUri, ICertificateAuthenticator auth, IConsumer consumer, IUser user, IJsonObjectMapper jsonMapper, IXmlObjectMapper xmlMapper, IRateLimiter rateLimiter)
            : base(CalculateUrl(baseUri, apiType), auth, consumer, user, jsonMapper, xmlMapper, rateLimiter)
        {
        }
    }
}
