using Xero.Api.Infrastructure.Http;
using Xero.Api.Payroll.Australia.Model;
using Xero.Api.Payroll.Australia.Request;
using Xero.Api.Payroll.Australia.Response;
using Xero.Api.Payroll.Common;

namespace Xero.Api.Payroll.Australia.Endpoints
{
    public class PayslipsEndpoint : PayrollEndpoint<PayslipsEndpoint, Payslip, PayslipRequest, PayslipsResponse>
    {
        public PayslipsEndpoint(XeroHttpClient client)
            : base(client, "payroll.xro/1.0/Payslip")
        {
        }
    }
}