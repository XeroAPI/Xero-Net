using Xero.Api.Common;
using Xero.Api.Core.Endpoints.Base;
using Xero.Api.Core.Model;
using Xero.Api.Core.Request;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public interface IBankTransactionsEndpoint : IXeroUpdateEndpoint<BankTransactionsEndpoint, BankTransaction, BankTransactionsRequest, BankTransactionsResponse>
    {
        IBankTransactionsEndpoint Page(int page);
    }

    public class BankTransactionsEndpoint : 
        FourDecimalPlacesEndpoint<BankTransactionsEndpoint, BankTransaction, BankTransactionsRequest, BankTransactionsResponse>,
        IBankTransactionsEndpoint
    {
        public BankTransactionsEndpoint(XeroHttpClient client)
            : base(client, "/api.xro/2.0/BankTransactions")
        {
        }

        public IBankTransactionsEndpoint Page(int page)
        {
            AddParameter("page", page);
            return this;
        }
    }
}