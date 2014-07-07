using Xero.Api.Infrastructure.Http;
using Xero.Api.Payroll.Common.Model;
using Xero.Api.Payroll.Common.Request;
using Xero.Api.Payroll.Common.Response;

namespace Xero.Api.Payroll.Common.Endpoints
{
    public class TimesheetsEndpoint : PayrollEndpoint<TimesheetsEndpoint, Timesheet, TimesheetsRequest, TimesheetsResponse>
    {
        public TimesheetsEndpoint(XeroHttpClient client)
            : base(client, "payroll.xro/1.0/Timesheets")
        {
        }
    }
}
