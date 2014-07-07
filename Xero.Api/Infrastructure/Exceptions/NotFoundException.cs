using System.Net;

namespace Xero.Api.Infrastructure.Exceptions
{
    public class NotFoundException
        : XeroApiException
    {
        public NotFoundException(string body)
            : base(HttpStatusCode.NotFound, body)
        {
        }
    }    
}