﻿using Xero.Api.Common;
using Xero.Api.Core.Model;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public class OrganisationEndpoint : XeroReadEndpoint<OrganisationEndpoint, Organisation, OrganisationResponse>
    {
        internal OrganisationEndpoint(XeroHttpClient client)
            : base(client, "/api.xro/2.0/Organisation")
        {
        }
    }
}