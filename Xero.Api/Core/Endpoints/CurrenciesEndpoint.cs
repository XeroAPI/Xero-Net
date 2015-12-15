using Xero.Api.Common;
using Xero.Api.Core.Model;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public interface ICurrenciesEndpoint : IXeroReadEndpoint<CurrenciesEndpoint, Currency, CurrenciesResponse>
    {
        
    }

    public class CurrenciesEndpoint : XeroReadEndpoint<CurrenciesEndpoint, Currency, CurrenciesResponse>,
        ICurrenciesEndpoint
    {
        internal CurrenciesEndpoint(XeroHttpClient client)
            : base(client, "/api.xro/2.0/Currencies")
        {
        }
    }
}