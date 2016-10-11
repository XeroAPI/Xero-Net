using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xero.Api.Common;
using Xero.Api.Infrastructure.Interfaces;

namespace Xero.Api.Core.Endpoints.Base
{
    public interface IAsyncXeroCreateEndpoint<T, TResult, TRequest, TResponse>
      : IAsyncXeroReadEndpoint<T, TResult, TResponse>
      where T : IAsyncXeroCreateEndpoint<T, TResult, TRequest, TResponse>
      where TResponse : IXeroResponse<TResult>, new()
      where TRequest : IXeroRequest<TResult>, new()
    {
        Task<IList<TResult>> CreateAsync(IList<TResult> items);

        Task<TResult> CreateAsync(TResult item);
    }
}
