using Xero.Api.Common;
using Xero.Api.Infrastructure.Interfaces;

namespace Xero.Api.Payroll.Common
{
    public abstract class PayrollApi : XeroApi
    {
        protected PayrollApi(string baseUri, IAuthenticator auth, IConsumer consumer, IUser user, IJsonObjectMapper readMapper, IXmlObjectMapper writeMapper)
            : base(baseUri, auth, consumer, user, readMapper, writeMapper)
        {
        }

        protected PayrollApi(string baseUri, ICertificateAuthenticator auth, IConsumer consumer, IUser user, IJsonObjectMapper readMapper, IXmlObjectMapper writeMapper)
            : base(baseUri, auth, consumer, user, readMapper, writeMapper)
        {
        }
    }
}