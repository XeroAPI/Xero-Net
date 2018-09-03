using System;
using System.Net;

namespace Xero.Api.Infrastructure.Exceptions
{
    [Serializable]
    public class NotAvailableException
        : XeroApiException
    {
        public NotAvailableException() { }

        public NotAvailableException(string body)
            : base(HttpStatusCode.ServiceUnavailable, body)
        {            
        }
    }
}