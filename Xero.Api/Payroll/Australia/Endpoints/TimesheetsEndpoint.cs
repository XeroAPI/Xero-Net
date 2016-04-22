using Xero.Api.Infrastructure.Http;
using Xero.Api.Payroll.Australia.Model;
using Xero.Api.Payroll.Australia.Request;
using Xero.Api.Payroll.Australia.Response;
using Xero.Api.Payroll.Common;

namespace Xero.Api.Payroll.Australia.Endpoints
{
    public class TimesheetsEndpoint : PayrollEndpoint<TimesheetsEndpoint, Timesheet, TimesheetsRequest, TimesheetsResponse>
    {
        public TimesheetsEndpoint(XeroHttpClientPayroll client)
            : base(client, "/Timesheets")
        {
        }
    }
}
