using System.Collections;
using Xero.Api.Common;
using Xero.Api.Core.Model;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public class PrepaymentsEndpoint : XeroReadEndpoint<PrepaymentsEndpoint, Prepayment, PrepaymentsResponse>
    {
        public PrepaymentsEndpoint(XeroHttpClient client)
            : base(client, "/api.xro/2.0/Prepayments")
        {
        }
    }
}
