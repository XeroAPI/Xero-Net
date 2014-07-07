using System.Collections.Generic;
using System.Linq;
using Xero.Api.Common;
using Xero.Api.Infrastructure.Http;
using Xero.Api.Infrastructure.Interfaces;

namespace Xero.Api.Payroll.Common
{
    public abstract class PayrollEndpoint<T, TResult, TRequest, TResponse>
        : XeroReadEndpoint<T, TResult, TResponse>
        where T : XeroReadEndpoint<T, TResult, TResponse>
        where TResponse : IXeroResponse<TResult>, new()
        where TRequest : IXeroRequest<TResult>, new()
    {
        protected PayrollEndpoint(XeroHttpClient client, string apiEndpointUrl)
            : base(client, apiEndpointUrl)
        {
        }

        public IEnumerable<TResult> Create(IEnumerable<TResult> items)
        {
            var request = new TRequest();
            request.AddRange(items);

            return Post(request);
        }

        public TResult Create(TResult item)
        {
            return Create(new [] { item }).First();
        }

        public IEnumerable<TResult> Update(IEnumerable<TResult> items)
        {
            return Create(items);
        }

        public TResult Update(TResult item)
        {
            return Update(new[] { item }).First();
        }

        protected IEnumerable<TResult> Post(TRequest data)
        {
            return Client.Post<TResult, TResponse>(ApiEndpointUrl, data);
        }
    }
}
