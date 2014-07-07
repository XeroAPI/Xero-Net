using System.Net;

namespace Xero.Api.Infrastructure.Exceptions
{
    internal class NotAvailableException
        : XeroApiException
    {
        public NotAvailableException(string body)
            : base(HttpStatusCode.ServiceUnavailable, body)
        {            
        }
    }
}