using System;
using Xero.Api.Common;
using Xero.Api.Core.Endpoints.Base;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Status;
using Xero.Api.Core.Request;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public partial interface IPurchaseOrdersEndpoint :
        IAsyncXeroUpdateEndpoint<PurchaseOrdersEndpoint, PurchaseOrder, PurchaseOrdersRequest, PurchaseOrdersResponse>, IPageableEndpoint<IPurchaseOrdersEndpoint>
    {
    }
}
