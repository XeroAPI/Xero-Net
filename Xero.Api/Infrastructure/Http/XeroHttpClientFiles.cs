using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.RateLimiter;

namespace Xero.Api.Infrastructure.Http
{


    public class XeroHttpClientFiles : XeroHttpClient, IXeroHttpClient
    {
        private static string apiType = "/files.xro/1.0";

        public XeroHttpClientFiles(string baseUri, IAuthenticator auth, IConsumer consumer, IUser user, IJsonObjectMapper jsonMapper, IXmlObjectMapper xmlMapper)
            : base(CalculateUrl(baseUri, apiType), auth, consumer, user, jsonMapper, xmlMapper)
        {
        }

        public XeroHttpClientFiles(string baseUri, IAuthenticator auth, IConsumer consumer, IUser user, IJsonObjectMapper jsonMapper, IXmlObjectMapper xmlMapper, IRateLimiter rateLimiter)
            : base(CalculateUrl(baseUri, apiType), auth, consumer, user, jsonMapper, xmlMapper, rateLimiter)
        {
        }

        public XeroHttpClientFiles(string baseUri, ICertificateAuthenticator auth, IConsumer consumer, IUser user, IJsonObjectMapper jsonMapper, IXmlObjectMapper xmlMapper)
            : base(CalculateUrl(baseUri, apiType), auth, consumer, user, jsonMapper, xmlMapper)
        {
        }

        public XeroHttpClientFiles(string baseUri, ICertificateAuthenticator auth, IConsumer consumer, IUser user, IJsonObjectMapper jsonMapper, IXmlObjectMapper xmlMapper, IRateLimiter rateLimiter)
            : base(CalculateUrl(baseUri, apiType), auth, consumer, user, jsonMapper, xmlMapper, rateLimiter)
        {
        }
    }
}
