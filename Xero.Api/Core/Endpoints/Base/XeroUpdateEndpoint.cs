using System.Collections.Generic;
using System.Linq;
using Xero.Api.Common;
using Xero.Api.Infrastructure.Http;
using Xero.Api.Infrastructure.Interfaces;

namespace Xero.Api.Core.Endpoints.Base
{
    public abstract class XeroUpdateEndpoint<T, TResult, TRequest, TResponse>
        : XeroCreateEndpoint<T, TResult, TRequest, TResponse>
        where T : XeroReadEndpoint<T, TResult, TResponse>
        where TResponse : IXeroResponse<TResult>, new()
        where TRequest : IXeroRequest<TResult>, new()
    {
        protected XeroUpdateEndpoint(XeroHttpClient client, string apiEndpointUrl)
            : base(client, apiEndpointUrl)
        {            
        }

        public IEnumerable<TResult> Update(IEnumerable<TResult> items)
        {
            var request = new TRequest();
            request.AddRange(items);

            return Post(request);
        }

        public TResult Update(TResult item)
        {
            return Update(new[] { item }).First();
        }

        protected IEnumerable<TResult> Post(TRequest data)
        {
            try
            {
                Client.Parameters = Parameters;
                return Client.Post<TResult, TResponse>(ApiEndpointUrl, data);
            }
            finally
            {
                ClearQueryString();
            }
        }
    }
}
