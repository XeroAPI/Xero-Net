using Xero.Api.Common;
using Xero.Api.Infrastructure.Http;
using Xero.Api.Payroll.America.Model;
using Xero.Api.Payroll.America.Response;

namespace Xero.Api.Payroll.America.Endpoints
{
    public class SettingsEndpoint : XeroReadEndpoint<SettingsEndpoint, Settings, SettingsResponse>
    {
        public SettingsEndpoint(XeroHttpClientPayroll client)
            : base(client, "/Settings")
        {
        }
    }
}