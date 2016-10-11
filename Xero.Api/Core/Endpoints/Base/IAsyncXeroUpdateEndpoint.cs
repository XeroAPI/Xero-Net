using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xero.Api.Common;
using Xero.Api.Infrastructure.Interfaces;

namespace Xero.Api.Core.Endpoints.Base
{
    public interface IAsyncXeroUpdateEndpoint<T, TResult, TRequest, TResponse>
        : IAsyncXeroCreateEndpoint<T, TResult, TRequest, TResponse>
        where T : IAsyncXeroUpdateEndpoint<T, TResult, TRequest, TResponse>
        where TResponse : IXeroResponse<TResult>, new()
        where TRequest : IXeroRequest<TResult>, new()
    {
        Task<IList<TResult>> UpdateAsync(IList<TResult> items);

        Task<TResult> UpdateAsync(TResult item);
    }
}
