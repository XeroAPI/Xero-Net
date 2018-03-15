using Xero.Api.Common;
using Xero.Api.Core.Model;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public interface IBrandingThemesEndpoint :
        IXeroReadEndpoint<IBrandingThemesEndpoint, BrandingTheme, BrandingThemesResponse>
    {
        
    }

    public class BrandingThemesEndpoint : XeroReadEndpoint<IBrandingThemesEndpoint, BrandingTheme, BrandingThemesResponse>, IBrandingThemesEndpoint
    {
        public BrandingThemesEndpoint(XeroHttpClient client)
            : base(client, "/api.xro/2.0/BrandingThemes")
        {
        }
    }
}