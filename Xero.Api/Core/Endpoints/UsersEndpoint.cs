﻿using Xero.Api.Common;
using Xero.Api.Core.Model;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public interface IUsersEndpoint : IXeroReadEndpoint<UsersEndpoint, User, UsersResponse>
    {
    }

    public class UsersEndpoint : XeroReadEndpoint<UsersEndpoint, User, UsersResponse>, IUsersEndpoint
    {
        internal UsersEndpoint(XeroHttpClient client)
            : base(client, "/Users")
        {
        }
    }
}