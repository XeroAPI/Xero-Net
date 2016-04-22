using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.RateLimiter;

namespace Xero.Api.Infrastructure.Http
{
    // This makes the calls to the web as text and asks the object mappers to convert to and from objects to text.
    // This knows nothing about the types being passed to and fro. (Except for the constraint in the generic type)
    public class XeroHttpClientPayroll : XeroHttpClient, IXeroHttpClient
    {
        const string apiType = "/payroll.xro/1.0";

        public XeroHttpClientPayroll(string baseUri, IAuthenticator auth, IConsumer consumer, IUser user, IJsonObjectMapper jsonMapper, IXmlObjectMapper xmlMapper)
            : base(CalculateUrl(baseUri, apiType), auth, consumer, user, jsonMapper, xmlMapper)
        {
        }

        public XeroHttpClientPayroll(string baseUri, IAuthenticator auth, IConsumer consumer, IUser user, IJsonObjectMapper jsonMapper, IXmlObjectMapper xmlMapper, IRateLimiter rateLimiter)
            : base(CalculateUrl(baseUri, apiType), auth, consumer, user, jsonMapper, xmlMapper, rateLimiter)
        {
        }

        public XeroHttpClientPayroll(string baseUri, ICertificateAuthenticator auth, IConsumer consumer, IUser user, IJsonObjectMapper jsonMapper, IXmlObjectMapper xmlMapper)
            : base(CalculateUrl(baseUri, apiType), auth, consumer, user, jsonMapper, xmlMapper)
        {
        }

        public XeroHttpClientPayroll(string baseUri, ICertificateAuthenticator auth, IConsumer consumer, IUser user, IJsonObjectMapper jsonMapper, IXmlObjectMapper xmlMapper, IRateLimiter rateLimiter)
            : base(CalculateUrl(baseUri, apiType), auth, consumer, user, jsonMapper, xmlMapper, rateLimiter)
        {
        }
    }
}
