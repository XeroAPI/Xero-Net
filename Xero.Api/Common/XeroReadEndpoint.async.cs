using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Xero.Api.Common
{
    partial class XeroReadEndpoint<T, TResult, TResponse> : IAsyncXeroReadEndpoint<T, TResult, TResponse>
    {
        public virtual Task<IList<TResult>> FindAsync()
        {
            return FindAsync(CancellationToken.None);
        }

        public virtual Task<IList<TResult>> FindAsync(CancellationToken cancellation)
        {
            return GetAsync(ApiEndpointUrl, null, cancellation);
        }

        public virtual Task<TResult> FindAsync(Guid child)
        {
            return FindAsync(child, CancellationToken.None);
        }

        public virtual Task<TResult> FindAsync(Guid child, CancellationToken cancellation)
        {
            return FindAsync(child.ToString("D"), cancellation);
        }

        public Task<TResult> FindAsync(string child)
        {
            return FindAsync(child, CancellationToken.None);
        }

        public async Task<TResult> FindAsync(string child, CancellationToken cancellation)
        {
            return (await GetAsync(ApiEndpointUrl, "/" + child, cancellation)).FirstOrDefault();
        }

        private Task<IList<TResult>> GetAsync(string endpoint, string child, CancellationToken cancellation)
        {
            try
            {
                if (Parameters == null)
                {
                    Parameters = new NameValueCollection();
                }

                Client.Where = _query;
                Client.Order = _orderBy;
                Client.ModifiedSince = _modifiedSince;
                Client.Parameters = Parameters;

                return Client.GetAsync<TResult, TResponse>(endpoint + (child ?? string.Empty), cancellation: cancellation);
            }
            finally
            {
                ClearQueryString();
            }
        }
    }
}
