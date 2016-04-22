using Xero.Api.Common;
using Xero.Api.Infrastructure.Http;
using Xero.Api.Payroll.Australia.Model;
using Xero.Api.Payroll.Australia.Response;

namespace Xero.Api.Payroll.Australia.Endpoints
{
    public class SettingsEndpoint : XeroReadEndpoint<SettingsEndpoint, Settings, SettingsResponse>
    {
        public SettingsEndpoint(XeroHttpClientPayroll client)
            : base(client, "/Settings")
        {
        }
    }
}