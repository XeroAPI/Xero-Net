using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Xero.Api.Core.Endpoints.Base
{
    partial class XeroCreateEndpoint<T, TResult, TRequest, TResponse>
        : IAsyncXeroCreateEndpoint<T, TResult, TRequest, TResponse>
    {
        public async Task<TResult> CreateAsync(TResult item, CancellationToken cancellation = default(CancellationToken))
        {
            return (await CreateAsync(new[] { item }, cancellation)).First();
        }

        public async Task<IList<TResult>> CreateAsync(IList<TResult> items, CancellationToken cancellation = default(CancellationToken))
        {
            var request = new TRequest();
            request.AddRange(items);
            return await PutAsync(request, cancellation);
        }

        protected async Task<IList<TResult>> PutAsync(TRequest data, CancellationToken cancellation = default(CancellationToken))
        {
            try
            {
                Client.Parameters = Parameters;
                return await Client.PutAsync<TResult, TResponse>(ApiEndpointUrl, data, cancellation);
            }
            finally
            {
                ClearQueryString();
            }
        }
    }
}
