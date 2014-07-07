using Xero.Api.Infrastructure.Http;
using Xero.Api.Payroll.America.Model;
using Xero.Api.Payroll.America.Request;
using Xero.Api.Payroll.America.Response;
using Xero.Api.Payroll.Common;

namespace Xero.Api.Payroll.America.Endpoints
{
    public class WorkLocationsEndpoint : PayrollEndpoint<WorkLocationsEndpoint, WorkLocation, WorkLocationsRequest, WorkLocationsResponse>
    {
        public WorkLocationsEndpoint(XeroHttpClient client)
            : base(client, "payroll.xro/1.0/WorkLocations")
        {
        }
    }
}