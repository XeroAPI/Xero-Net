﻿using Xero.Api.Core;
using Xero.Api.Infrastructure.RateLimiter;
using Xero.Api.Serialization;

namespace Xero.Api.Example.Applications.Private
{
    public class Core : XeroCoreApi
    {
        private static readonly DefaultMapper Mapper = new DefaultMapper();
        private static readonly Settings ApplicationSettings = new Settings();

        public Core(bool includeRateLimiter = false) :
            base(ApplicationSettings.Uri,
                new PrivateAuthenticator(ApplicationSettings.SigningCertificate),
                ApplicationSettings.Consumer,
                null,
                Mapper,
                Mapper,
                includeRateLimiter ? new RateLimiter() : null)
        {
        }
    }
}