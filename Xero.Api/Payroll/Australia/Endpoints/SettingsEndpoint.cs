using Xero.Api.Common;
using Xero.Api.Infrastructure.Http;
using Xero.Api.Payroll.Australia.Model;
using Xero.Api.Payroll.Australia.Response;

namespace Xero.Api.Payroll.Australia.Endpoints
{
    public class SettingsEndpoint : XeroReadEndpoint<SettingsEndpoint, Settings, SettingsResponse>
    {
        public SettingsEndpoint(XeroHttpClient client)
            : base(client, "payroll.xro/1.0/Settings")
        {
        }
    }
}