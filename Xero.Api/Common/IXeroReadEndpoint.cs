using System;
using System.Collections.Generic;
using Xero.Api.Infrastructure.Interfaces;

namespace Xero.Api.Common
{
    public interface IXeroReadEndpoint<T, TResult, TResponse> 
        where T : XeroReadEndpoint<T, TResult, TResponse>
        where TResponse : IXeroResponse<TResult>, new()
    {
        string QueryString { get; }
        T ModifiedSince(DateTime modified);
        T Where(string query);
        T Or(string query);
        T And(string query);
        T OrderBy(string query);
        T OrderByDescending(string query);
        T UseFourDecimalPlaces(bool use4Dp);
        IEnumerable<TResult> Find();
        IEnumerable<TResult> Find(bool resetQuery);
        TResult Find(Guid child);
        TResult Find(Guid child, bool resetQuery);
        TResult Find(string child);
        TResult Find(string child, bool resetQuery);
        void ClearQueryString();
    }
}