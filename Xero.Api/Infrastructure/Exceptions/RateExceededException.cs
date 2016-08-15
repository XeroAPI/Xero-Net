using System;
using System.Net;

namespace Xero.Api.Infrastructure.Exceptions
{
    [Serializable]
    public class RateExceededException
        : XeroApiException
    {
        public RateExceededException() { }

        public RateExceededException(string message) : base(HttpStatusCode.ServiceUnavailable, message)
        {            
        }
    }
}