using Xero.Api.Infrastructure.Http;
using Xero.Api.Payroll.Australia.Model;
using Xero.Api.Payroll.Australia.Request;
using Xero.Api.Payroll.Australia.Response;
using Xero.Api.Payroll.Common;

namespace Xero.Api.Payroll.Australia.Endpoints
{
    public class PayItemsEndpoint : PayrollEndpoint<PayItemsEndpoint, PayItems, PayItemsRequest, PayItemsResponse>
    {
        public PayItemsEndpoint(XeroHttpClientPayroll client)
            : base(client, "/PayItems")
        {
        }
    }
}
