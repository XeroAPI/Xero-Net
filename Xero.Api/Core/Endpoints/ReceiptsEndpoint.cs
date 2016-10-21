﻿using Xero.Api.Core.Endpoints.Base;
using Xero.Api.Core.Model;
using Xero.Api.Core.Request;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public partial interface IReceiptsEndpoint : IXeroUpdateEndpoint<ReceiptsEndpoint, Receipt, ReceiptsRequest, ReceiptsResponse>
    {

    }

    public class ReceiptsEndpoint
        : FourDecimalPlacesEndpoint<ReceiptsEndpoint, Receipt, ReceiptsRequest, ReceiptsResponse>, IReceiptsEndpoint
    {
        public ReceiptsEndpoint(XeroHttpClient client)
            : base(client, "/api.xro/2.0/Receipts")
        {
        }
    }
}