using System;
using System.Net;

namespace Xero.Api.Infrastructure.Exceptions
{
    [Serializable]
    public class NotFoundException
        : XeroApiException
    {
        public NotFoundException() { }

        public NotFoundException(string body)
            : base(HttpStatusCode.NotFound, body)
        {
        }
    }    
}