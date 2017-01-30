using Xero.Api.Common;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.RateLimiter;

namespace Xero.Api.Payroll.Common
{
    public abstract class PayrollApi : XeroApi
    {
        protected PayrollApi(string baseUri, IAuthenticator auth, IConsumer consumer, IUser user, IJsonObjectMapper readMapper, IXmlObjectMapper writeMapper, IRateLimiter rateLimiter)
            : base(baseUri, auth, consumer, user, readMapper, writeMapper, rateLimiter)
        {
        }
    }
}