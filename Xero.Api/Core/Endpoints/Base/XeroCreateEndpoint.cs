using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Xero.Api.Common;
using Xero.Api.Infrastructure.Http;
using Xero.Api.Infrastructure.Interfaces;

namespace Xero.Api.Core.Endpoints.Base
{
    public abstract class XeroCreateEndpoint<T, TResult, TRequest, TResponse>
        : XeroReadEndpoint<T, TResult, TResponse>
        where T : XeroReadEndpoint<T, TResult, TResponse>
        where TResponse : IXeroResponse<TResult>, new()
        where TRequest : IXeroRequest<TResult>, new()
    {
        protected XeroCreateEndpoint(XeroHttpClient client, string apiEndpointUrl)
            : base(client, apiEndpointUrl)
        {
        }

        public IEnumerable<TResult> Create(IEnumerable<TResult> items)
        {
            var request = new TRequest();
            request.AddRange(items);

            return Put(request);
        }

        public TResult Create(TResult item)
        {
            return Create(new[] { item }).First();
        }

        protected IEnumerable<TResult> Put(TRequest data)
        {
            Client.Parameters = Parameters;
            return Client.Put<TResult, TResponse>(ApiEndpointUrl, data);
        }        
    }
}
