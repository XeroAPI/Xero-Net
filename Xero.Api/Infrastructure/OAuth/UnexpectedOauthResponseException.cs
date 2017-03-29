using System;
using System.Net;

namespace Xero.Api.Infrastructure.OAuth
{
    public class UnexpectedOauthResponseException : Exception
    {
        public HttpStatusCode ResponseStatusCode { get; set; }
        public string ResponseBody { get; set; }

        public UnexpectedOauthResponseException(HttpStatusCode responseStatusCode, string responseBody) : base("An unexpected HTTP response was returned while performing OAuth operations")
        {
            ResponseStatusCode = responseStatusCode;
            ResponseBody = responseBody;
        }
    }
}