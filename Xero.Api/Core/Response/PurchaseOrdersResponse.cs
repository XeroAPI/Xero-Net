using System.Collections.Generic;
using Xero.Api.Common;
using Xero.Api.Core.Model;

namespace Xero.Api.Core.Response
{
    public class PurchaseOrdersResponse : XeroResponse<PurchaseOrder>
    {
        public List<PurchaseOrder> PurchaseOrders { get; set; }

        public override IList<PurchaseOrder> Values
        {
            get { return PurchaseOrders; }
        }
    }
}
