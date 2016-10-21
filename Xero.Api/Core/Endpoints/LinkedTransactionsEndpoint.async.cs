using System;
using System.Net;
using System.Threading.Tasks;
using Xero.Api.Common;
using Xero.Api.Core.Endpoints.Base;
using Xero.Api.Core.Model;
using Xero.Api.Core.Request;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public partial interface ILinkedTransactionsEndpoint : IAsyncXeroUpdateEndpoint<LinkedTransactionsEndpoint, LinkedTransaction, LinkedTransactionsRequest, LinkedTransactionsResponse>, IPageableEndpoint<ILinkedTransactionsEndpoint>
    {
        Task DeleteAsync(LinkedTransaction linkedTransaction);
    }

    public partial class LinkedTransactionsEndpoint
        : XeroUpdateEndpoint<LinkedTransactionsEndpoint, LinkedTransaction, LinkedTransactionsRequest, LinkedTransactionsResponse>, ILinkedTransactionsEndpoint
    {
        public async Task DeleteAsync(LinkedTransaction linkedTransaction)
        {
            var endpoint = string.Format("/api.xro/2.0/LinkedTransactions/{0}", linkedTransaction.Id);

            HandleResponse(await Client.Client.DeleteAsync(endpoint));
        }
    }
}
