using Xero.Api.Core.Endpoints.Base;
using Xero.Api.Core.Model;
using Xero.Api.Core.Request;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public interface ITaxRatesEndpoint : IXeroUpdateEndpoint<TaxRatesEndpoint, TaxRate, TaxRatesRequest, TaxRatesResponse>
    {

    }

    public class TaxRatesEndpoint
        : XeroUpdateEndpoint<TaxRatesEndpoint, TaxRate, TaxRatesRequest, TaxRatesResponse>, ITaxRatesEndpoint
    {
        internal TaxRatesEndpoint(XeroHttpClient client)
            : base(client, "/api.xro/2.0/TaxRates")
        {
        }
    }
}