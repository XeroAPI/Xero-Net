﻿using System;
using System.Net;

namespace Xero.Api.Infrastructure.Exceptions
{
    [Serializable]
    public class XeroApiException
        : Exception
    {
        public XeroApiException() { }

        public XeroApiException(HttpStatusCode statusCode, string body)
            : base(body)
        {
            Code = statusCode;
        }

        public HttpStatusCode Code { get; private set; }
    }
}