using System;
using System.Net;

namespace Xero.Api.Infrastructure.Exceptions
{
    [Serializable]
    public class UnauthorizedException
        : XeroApiException
    {
        public UnauthorizedException() { }

        public UnauthorizedException(string body)
            : base(HttpStatusCode.Unauthorized, body)
        {
        }
    }
}