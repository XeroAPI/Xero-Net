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
    public interface IPurchaseOrdersEndpoint :
        IXeroCreateEndpoint<PurchaseOrdersEndpoint, PurchaseOrder, PurchaseOrdersRequest, PurchaseOrdersResponse>, IPageableEndpoint<IPurchaseOrdersEndpoint>
    {
        PurchaseOrdersEndpoint Status(PurchaseOrderStatus status);
        PurchaseOrdersEndpoint DateFrom(DateTime dateFrom);
        PurchaseOrdersEndpoint DateTo(DateTime dateTo);
    }

    public class PurchaseOrdersEndpoint : XeroCreateEndpoint<PurchaseOrdersEndpoint, PurchaseOrder, PurchaseOrdersRequest, PurchaseOrdersResponse>, IPurchaseOrdersEndpoint
    {
        public PurchaseOrdersEndpoint(XeroHttpClient client) :
            base(client, "/api.xro/2.0/PurchaseOrders")
        {
            Page(1);
        }

        public IPurchaseOrdersEndpoint Page(int page)
        {
            AddParameter("page", page);
            return this;
        }

        public PurchaseOrdersEndpoint Status(PurchaseOrderStatus status)
        {
            AddParameter("status", status.ToString().ToUpper());
            return this;
        }

        public PurchaseOrdersEndpoint DateFrom(DateTime dateFrom)
        {
            AddParameter("dateFrom", dateFrom.ToString("yyyy-MM-dd"));
            return this;
        }

        public PurchaseOrdersEndpoint DateTo(DateTime dateTo)
        {
            AddParameter("dateTo", dateTo.ToString("yyyy-MM-dd"));
            return this;
        }

        public override void ClearQueryString()
        {
            base.ClearQueryString();
            Page(1);
        }
    }
}
