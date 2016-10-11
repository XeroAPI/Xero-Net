using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xero.Api.Core.Endpoints.Base
{
    partial class XeroCreateEndpoint<T, TResult, TRequest, TResponse>
        : IAsyncXeroCreateEndpoint<T, TResult, TRequest, TResponse>
    {
        public async Task<TResult> CreateAsync(TResult item)
        {
            return (await CreateAsync(new[] { item })).First();
        }

        public async Task<IList<TResult>> CreateAsync(IList<TResult> items)
        {
            var request = new TRequest();
            request.AddRange(items);
            return await PutAsync(request);
        }

        protected async Task<IList<TResult>> PutAsync(TRequest data)
        {
            try
            {
                Client.Parameters = Parameters;
                return await Client.PutAsync<TResult, TResponse>(ApiEndpointUrl, data);
            }
            finally
            {
                ClearQueryString();
            }
        }
    }
}
