using Xero.Api.Core.Endpoints.Base;
using Xero.Api.Core.Model;
using Xero.Api.Core.Request;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public class PaymentsEndpoint
        : FourDecimalPlacesEndpoint<PaymentsEndpoint, Payment, PaymentsRequest, PaymentsResponse>
    {
        public PaymentsEndpoint(XeroHttpClient client) :
            base(client, "/api.xro/2.0/Payments")
        {
        }
    }
}