﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xero.Api.Common;
using Xero.Api.Infrastructure.Interfaces;

namespace Xero.Api.Core.Endpoints.Base
{
    public interface IXeroUpdateEndpoint<T, TResult, TRequest, TResponse>
        : IXeroCreateEndpoint<T, TResult, TRequest, TResponse>
        where T : IXeroUpdateEndpoint<T, TResult, TRequest, TResponse>
        where TResponse : IXeroResponse<TResult>, new()
        where TRequest : IXeroRequest<TResult>, new()
    {
        IEnumerable<TResult> Update(IEnumerable<TResult> items);
        TResult Update(TResult item);
    }
}
