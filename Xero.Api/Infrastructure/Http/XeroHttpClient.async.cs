using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xero.Api.Common;
using Xero.Api.Infrastructure.Interfaces;

namespace Xero.Api.Infrastructure.Http
{
    /// <summary>
    /// This implements the async version of the HttpClient API's
    /// </summary>
    partial class XeroHttpClient
    {
        public async Task<IList<TResult>> GetAsync<TResult, TResponse>(string endPoint, CancellationToken cancellation = default(CancellationToken)) where TResponse : IXeroResponse<TResult>, new()
        {
            Client.ModifiedSince = ModifiedSince;
            return (IList<TResult>)Read<TResult, TResponse>(await Client.GetAsync(endPoint, new QueryGenerator(Where, Order, Parameters).UrlEncodedQueryString, cancellation));
        }

        internal async Task<IList<TResult>> PostAsync<TResult, TResponse>(string endpoint, byte[] data, string mimeType, CancellationToken cancellation = default(CancellationToken))
            where TResponse : IXeroResponse<TResult>, new()
        {
            return (IList<TResult>)Read<TResult, TResponse>(await Client.PostAsync(endpoint, data, mimeType, new QueryGenerator(null, null, Parameters).UrlEncodedQueryString, cancellation));
        }

        public async Task<IList<TResult>> PostAsync<TResult, TResponse>(string endPoint, object data, CancellationToken cancellation = default(CancellationToken))
            where TResponse : IXeroResponse<TResult>, new()
        {
            return (IList<TResult>)Read<TResult, TResponse>(await Client.PostAsync(endPoint, XmlMapper.To(data), query: new QueryGenerator(null, null, Parameters).UrlEncodedQueryString, cancellation: cancellation));
        }

        public async Task<IList<TResult>> PutAsync<TResult, TResponse>(string endPoint, object data, CancellationToken cancellation = default(CancellationToken))
            where TResponse : IXeroResponse<TResult>, new()
        {
            return (IList<TResult>)Read<TResult, TResponse>(await Client.PutAsync(endPoint, XmlMapper.To(data), query: new QueryGenerator(null, null, Parameters).UrlEncodedQueryString, cancellation: cancellation));
        }

        public async Task<IList<TResult>> DeleteAsync<TResult, TResponse>(string endPoint, CancellationToken cancellation = default(CancellationToken))
            where TResponse : IXeroResponse<TResult>, new()
        {
            return (IList<TResult>)Read<TResult, TResponse>(await Client.DeleteAsync(endPoint, cancellation));
        }

        internal Task<Response> GetAsync(string endpoint, string mimeType)
        {
            return Client.GetAsync(endpoint, null);
        }
    }
}
