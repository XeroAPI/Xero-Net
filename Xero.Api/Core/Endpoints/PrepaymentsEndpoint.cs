using System.Collections;
using Xero.Api.Common;
using Xero.Api.Core.Model;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public interface IPrepaymentsEndpoint : IXeroReadEndpoint<PrepaymentsEndpoint, Prepayment, PrepaymentsResponse>, IPageableEndpoint<IPrepaymentsEndpoint>
    {
    }

    public class PrepaymentsEndpoint : XeroReadEndpoint<PrepaymentsEndpoint, Prepayment, PrepaymentsResponse>, IPrepaymentsEndpoint
    {
        public PrepaymentsEndpoint(XeroHttpClient client)
            : base(client, "/api.xro/2.0/Prepayments")
        {
            Page(1);
        }

        public IPrepaymentsEndpoint Page(int page)
        {
            AddParameter("page", page);
            return this;
        }
    }
}
