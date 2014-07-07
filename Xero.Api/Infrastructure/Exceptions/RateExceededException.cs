using System.Net;

namespace Xero.Api.Infrastructure.Exceptions
{
    public class RateExceededException
        : XeroApiException
    {
        public RateExceededException(string message) : base(HttpStatusCode.ServiceUnavailable, message)
        {            
        }
    }
}