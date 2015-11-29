﻿using System.Net;

namespace Xero.Api.Infrastructure.Exceptions
{
    public class UnauthorizedException
        : XeroApiException
    {
        public UnauthorizedException(string body)
            : base(HttpStatusCode.Unauthorized, body)
        {
        }
    }
}