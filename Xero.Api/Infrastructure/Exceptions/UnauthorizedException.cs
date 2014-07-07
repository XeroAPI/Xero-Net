using System.Net;

namespace Xero.Api.Infrastructure.Exceptions
{
    internal class UnauthorizedException
        : XeroApiException
    {
        public UnauthorizedException(string body)
            : base(HttpStatusCode.Unauthorized, body)
        {
        }
    }
}