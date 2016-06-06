using System;
using System.Net;

namespace Xero.Api.Infrastructure.Exceptions
{
    [Serializable]
    internal class NotAvailableException
        : XeroApiException
    {
        public NotAvailableException() { }

        public NotAvailableException(string body)
            : base(HttpStatusCode.ServiceUnavailable, body)
        {            
        }
    }
}