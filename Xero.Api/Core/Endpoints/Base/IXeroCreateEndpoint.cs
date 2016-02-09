using System.Collections.Generic;
using Xero.Api.Common;
using Xero.Api.Infrastructure.Interfaces;

namespace Xero.Api.Core.Endpoints.Base
{
    public interface IXeroCreateEndpoint<T, TResult, TRequest, TResponse>
        : IXeroReadEndpoint<T, TResult, TResponse>
        where T : XeroReadEndpoint<T, TResult, TResponse>
        where TResponse : IXeroResponse<TResult>, new()
        where TRequest : IXeroRequest<TResult>, new()
    {
        IEnumerable<TResult> Create(IEnumerable<TResult> items);
        TResult Create(TResult item);
        IXeroCreateEndpoint<T, TResult, TRequest, TResponse> SummarizeErrors(bool summarize);
    }
}
