using System.Net;
using System.Threading.Tasks;
using Xero.Api.Core.Endpoints.Base;
using Xero.Api.Core.Model;
using Xero.Api.Core.Request;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public partial interface IItemsEndpoint : IAsyncXeroUpdateEndpoint<ItemsEndpoint, Item, ItemsRequest, ItemsResponse>
    {
        Task DeleteAsync(Item itemToDelete);
    }

    public partial class ItemsEndpoint
    {
        public async Task DeleteAsync(Item itemToDelete)
        {
            var endpoint = string.Format("/api.xro/2.0/Items/{0}", itemToDelete.Id);

            HandleResponse(await Client.Client.DeleteAsync(endpoint));
        }
    }
}