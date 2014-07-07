using System.Runtime.Serialization;
using Xero.Api.Infrastructure.Http;
using Xero.Api.Payroll.Australia.Model;
using Xero.Api.Payroll.Australia.Request;
using Xero.Api.Payroll.Australia.Response;
using Xero.Api.Payroll.Common;

namespace Xero.Api.Payroll.Australia.Endpoints
{
    [DataContract(Namespace = "")]
    public class SuperFundsEndpoint : PayrollEndpoint<SuperFundsEndpoint, SuperFund, SuperFundsRequest, SuperFundsResponse>
    {
        public SuperFundsEndpoint(XeroHttpClient client)
            : base(client, "payroll.xro/1.0/SuperFunds")
        {
        }
    }
}