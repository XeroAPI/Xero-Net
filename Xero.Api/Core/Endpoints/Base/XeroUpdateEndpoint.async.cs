using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Xero.Api.Core.Endpoints.Base
{
    partial class XeroUpdateEndpoint<T, TResult, TRequest, TResponse>
        : IAsyncXeroUpdateEndpoint<T, TResult, TRequest, TResponse>
    {
        public virtual async Task<TResult> UpdateAsync(TResult item, CancellationToken cancellation = default(CancellationToken))
        {
            return (await UpdateAsync(new[] { item }, cancellation)).First();
        }

        public virtual async Task<IList<TResult>> UpdateAsync(IList<TResult> items, CancellationToken cancellation = default(CancellationToken))
        {
            var request = new TRequest();
            request.AddRange(items);
            return await PostAsync(request, cancellation);
        }

        protected async Task<IList<TResult>> PostAsync(TRequest data, CancellationToken cancellation = default(CancellationToken))
        {
            try
            {
                Client.Parameters = Parameters;
                return await Client.PostAsync<TResult, TResponse>(ApiEndpointUrl, data, cancellation);
            }
            finally
            {
                ClearQueryString();
            }
        }
    }
}
