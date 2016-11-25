﻿using System;
using System.Net;

namespace Xero.Api.Infrastructure.Interfaces
{
    public interface IAuthenticator
    {
        void Authenticate(HttpWebRequest request, IConsumer consumer, IUser user);
    }
}
