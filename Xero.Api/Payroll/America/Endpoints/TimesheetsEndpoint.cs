using Xero.Api.Infrastructure.Http;
using Xero.Api.Payroll.America.Model;
using Xero.Api.Payroll.America.Request;
using Xero.Api.Payroll.America.Response;
using Xero.Api.Payroll.Common;

namespace Xero.Api.Payroll.America.Endpoints
{
    public class TimesheetsEndpoint : PayrollEndpoint<TimesheetsEndpoint, Timesheet, TimesheetsRequest, TimesheetsResponse>
    {
        public TimesheetsEndpoint(XeroHttpClientPayroll client)
            : base(client, "/Timesheets")
        {
        }
    }
}
