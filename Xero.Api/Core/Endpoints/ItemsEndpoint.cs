using System.Linq;
using System.Net;
using Xero.Api.Core.Endpoints.Base;
using Xero.Api.Core.Model;
using Xero.Api.Core.Request;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public interface IItemsEndpoint : IXeroUpdateEndpoint<ItemsEndpoint, Item, ItemsRequest, ItemsResponse>
    {

    }

    public class ItemsEndpoint
        : FourDecimalPlacesEndpoint<ItemsEndpoint, Item, ItemsRequest, ItemsResponse>, IItemsEndpoint
    {
        public ItemsEndpoint(XeroHttpClient client) :
            base(client, "/api.xro/2.0/Items")
        {
        }

        public void Delete(Item itemToDelete)
        {
            var endpoint = string.Format("/api.xro/2.0/Items/{0}", itemToDelete.Id);

            HandleResponse(Client
                .Client
                .Delete(endpoint));
        }

        private ItemsResponse HandleResponse(Infrastructure.Http.Response response)
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = Client.JsonMapper.From<ItemsResponse>(response.Body);
                return result;
            }

            Client.HandleErrors(response);

            return null;
        }
    }
}