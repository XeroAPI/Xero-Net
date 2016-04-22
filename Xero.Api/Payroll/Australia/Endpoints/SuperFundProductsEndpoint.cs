using System.Runtime.Serialization;
using Xero.Api.Common;
using Xero.Api.Infrastructure.Http;
using Xero.Api.Payroll.Australia.Model;
using Xero.Api.Payroll.Australia.Response;

namespace Xero.Api.Payroll.Australia.Endpoints
{
    [DataContract(Namespace = "")]
    public class SuperFundProductsEndpoint : XeroReadEndpoint<SuperFundProductsEndpoint, SuperFundProduct, SuperFundProductsResponse>
    {
        public SuperFundProductsEndpoint(XeroHttpClientPayroll client)
            : base(client, "/SuperFundProducts")
        {
        }
    }
}