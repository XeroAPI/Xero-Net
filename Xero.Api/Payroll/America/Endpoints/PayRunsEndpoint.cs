using Xero.Api.Infrastructure.Http;
using Xero.Api.Payroll.America.Model;
using Xero.Api.Payroll.America.Request;
using Xero.Api.Payroll.America.Response;
using Xero.Api.Payroll.Common;

namespace Xero.Api.Payroll.America.Endpoints
{
    public class PayRunsEndpoint : PayrollEndpoint<PayRunsEndpoint, PayRun, PayRunsRequest, PayRunsResponse>
    {
        public PayRunsEndpoint(XeroHttpClientPayroll client)
            : base(client, "/PayRuns")
        {
        }
    }
}
