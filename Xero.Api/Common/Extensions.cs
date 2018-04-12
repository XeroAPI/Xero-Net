using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Xero.Api.Core.Endpoints;
using Xero.Api.Core.Endpoints.Base;
using Xero.Api.Core.Model;
using Xero.Api.Infrastructure.Interfaces;

namespace Xero.Api.Common
{
    public static class Extensions
    {
        public static void Add(this NameValueCollection collection, string name, Guid? value)
        {
            if (value.HasValue)
            {
                collection.Add(name, value.Value.ToString("D"));
            }
        }

        public static void Add(this NameValueCollection collection, string name, int? value)
        {
            if (value.HasValue)
            {
                collection.Add(name, value.Value.ToString("D"));
            }
        }

        public static void Add(this NameValueCollection collection, string name, bool? value)
        {
            if (value.HasValue)
            {
                collection.Add(name, value.Value.ToString().ToLower());
            }
        }

        /// <summary>
        /// Get history/notes associated/linked/attached to the <paramref name="source"/> 
        /// as per https://developer.xero.com/documentation/api/history-and-notes.
        /// </summary>
        /// <param name="endpoint">The <see cref="IXeroReadEndpoint{T,TResult,TResponse}">endpoint</see> to leverage to communicate with the Xero API.</param>
        /// <param name="source">The item/object that you want to get history for.</param>
        /// <returns>History/note information.</returns>
        public static IEnumerable<History> GetHistory<T, TResult, TResponse>(this IXeroReadEndpoint<T, TResult, TResponse> endpoint, TResult source)
            where T : XeroReadEndpoint<T, TResult, TResponse>
            where TResponse : IXeroResponse<TResult>, new()
            where TResult : IHasId
        {
            return GetHistory((T) endpoint, source);
        }

        /// <summary>
        /// Get history/notes associated/linked/attached to the <paramref name="source"/> 
        /// as per https://developer.xero.com/documentation/api/history-and-notes.
        /// </summary>
        /// <param name="endpoint">The <see cref="XeroReadEndpoint{T,TResult,TResponse}">endpoint</see> to leverage to communicate with the Xero API.</param>
        /// <param name="source">The item/object that you want to get history for.</param>
        /// <returns>History/note information.</returns>
        public static IEnumerable<History> GetHistory<T, TResult, TResponse>(this XeroReadEndpoint<T, TResult, TResponse> endpoint, TResult source)
            where T : XeroReadEndpoint<T, TResult, TResponse>
            where TResponse : IXeroResponse<TResult>, new()
            where TResult : IHasId
        {
            return new HistoryEndpoint(endpoint.Client).Get(endpoint, source);
        }

        /// <summary>
        /// Add/link/associate a note to the <paramref name="source"/>
        /// as per https://developer.xero.com/documentation/api/history-and-notes.
        /// </summary>
        /// <param name="endpoint">The <see cref="IXeroReadEndpoint{T,TResult,TResponse}">endpoint</see> to leverage to communicate with the Xero API.</param>
        /// <param name="source">The item/object that you want to get history for.</param>
        /// <param name="noteContent">The content of the note to add/link/associate.</param>
        /// <returns>The created history/note information.</returns>
        public static History AddNote<T, TResult, TRequest, TResponse>(this IXeroCreateEndpoint<T, TResult, TRequest, TResponse> endpoint, TResult source, string noteContent)
            where T : XeroReadEndpoint<T, TResult, TResponse>
            where TResponse : IXeroResponse<TResult>, new()
            where TRequest : IXeroRequest<TResult>, new()
            where TResult : IHasId
        {
            return AddNote((XeroCreateEndpoint<T, TResult, TRequest, TResponse>)endpoint, source, noteContent);
        }

        /// <summary>
        /// Add/link/associate a note to the <paramref name="source"/>
        /// as per https://developer.xero.com/documentation/api/history-and-notes.
        /// </summary>
        /// <param name="endpoint">The <see cref="XeroReadEndpoint{T,TResult,TResponse}">endpoint</see> to leverage to communicate with the Xero API.</param>
        /// <param name="source">The item/object that you want to get history for.</param>
        /// <param name="noteContent">The content of the note to add/link/associate.</param>
        /// <returns>The created history/note information.</returns>
        public static History AddNote<T, TResult, TRequest, TResponse>(this XeroCreateEndpoint<T, TResult, TRequest, TResponse> endpoint, TResult source, string noteContent)
            where T : XeroReadEndpoint<T, TResult, TResponse>
            where TResponse : IXeroResponse<TResult>, new()
            where TRequest : IXeroRequest<TResult>, new()
            where TResult : IHasId
        {
            return new HistoryEndpoint(endpoint.Client).Put(endpoint, source, noteContent);
        }
    }
}