using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xero.Api.Infrastructure.Interfaces;

namespace Xero.Api.Common
{
    public interface IAsyncXeroReadEndpoint<T, TResult, TResponse> : IXeroReadEndpoint<T, TResult, TResponse>
    where T : IAsyncXeroReadEndpoint<T, TResult, TResponse>
    where TResponse : IXeroResponse<TResult>, new()
    {
        Task<IList<TResult>> FindAsync();
        Task<IList<TResult>> FindAsync(CancellationToken cancellation);
        Task<TResult> FindAsync(Guid child);
        Task<TResult> FindAsync(Guid child, CancellationToken cancellation);
        Task<TResult> FindAsync(string child);
        Task<TResult> FindAsync(string child, CancellationToken cancellation);
    }
}
