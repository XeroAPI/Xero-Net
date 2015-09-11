using Xero.Api.Core.Endpoints.Base;
using Xero.Api.Core.Model;
using Xero.Api.Core.Request;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public class LinkedTransactionsEndpoint
        : XeroUpdateEndpoint<LinkedTransactionsEndpoint, LinkedTransaction, LinkedTransactionsRequest, LinkedTransactionsResponse>
    {
        internal LinkedTransactionsEndpoint(XeroHttpClient client) 
            : base(client, "/api.xro/2.0/LinkedTransactions")
        {
            Page(1);
        }

        public LinkedTransactionsEndpoint Page(int page)
        {
            AddParameter("page", page);
            return this;
        }

        public override void ClearQueryString()
        {
            base.ClearQueryString();
            Page(1);
        }
    }
}
