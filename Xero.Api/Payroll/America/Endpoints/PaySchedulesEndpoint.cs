using Xero.Api.Infrastructure.Http;
using Xero.Api.Payroll.America.Model;
using Xero.Api.Payroll.America.Request;
using Xero.Api.Payroll.America.Response;
using Xero.Api.Payroll.Common;

namespace Xero.Api.Payroll.America.Endpoints
{
    public class PaySchedulesEndpoint : PayrollEndpoint<PaySchedulesEndpoint, PaySchedule, PaySchedulesRequest, PaySchedulesResponse>
    {
        public PaySchedulesEndpoint(XeroHttpClientPayroll client)
            : base(client, "/PaySchedules")
        {
        }
    }
}