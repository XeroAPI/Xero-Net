using System.Collections.Generic;
using System.Linq;
using Xero.Api.Common;
using Xero.Api.Infrastructure.Http;
using Xero.Api.Infrastructure.Interfaces;

namespace Xero.Api.Core.Endpoints.Base
{
    public abstract partial class XeroCreateEndpoint<T, TResult, TRequest, TResponse>
        : XeroReadEndpoint<T, TResult, TResponse>, IXeroCreateEndpoint<T, TResult, TRequest, TResponse>
        where T : XeroCreateEndpoint<T, TResult, TRequest, TResponse>
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

        public T SummarizeErrors(bool summarize)
        {
            AddParameter("summarizeErrors", summarize);
            return (T)this;
        }

        protected IEnumerable<TResult> Put(TRequest data)
        {
            try
            {
                Client.Parameters = Parameters;
                return Client.Put<TResult, TResponse>(ApiEndpointUrl, data);
            }
            finally
            {
                ClearQueryString();
            }
        }
    }
}
