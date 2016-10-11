using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xero.Api.Core.Endpoints.Base
{
    partial class XeroUpdateEndpoint<T, TResult, TRequest, TResponse>
        : IAsyncXeroUpdateEndpoint<T, TResult, TRequest, TResponse>
    {
        public virtual async Task<TResult> UpdateAsync(TResult item)
        {
            return (await UpdateAsync(new[] { item })).First();
        }

        public virtual async Task<IList<TResult>> UpdateAsync(IList<TResult> items)
        {
            var request = new TRequest();
            request.AddRange(items);
            return await PostAsync(request);
        }

        protected async Task<IList<TResult>> PostAsync(TRequest data)
        {
            try
            {
                Client.Parameters = Parameters;
                return await Client.PostAsync<TResult, TResponse>(ApiEndpointUrl, data);
            }
            finally
            {
                ClearQueryString();
            }
        }
    }
}
