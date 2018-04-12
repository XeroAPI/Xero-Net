using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xero.Api.Common;
using Xero.Api.Core.Endpoints.Base;
using Xero.Api.Core.Model;
using Xero.Api.Core.Request;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;
using Xero.Api.Infrastructure.Interfaces;

namespace Xero.Api.Core.Endpoints
{
    public interface IHistoryEndpoint
        : IXeroCreateEndpoint<HistoryEndpoint, History, HistoryRequest, HistoryResponse>,
        IPageableEndpoint<IHistoryEndpoint>
    {

    }

    public class HistoryEndpoint
        : XeroCreateEndpoint<HistoryEndpoint, History, HistoryRequest, HistoryResponse>, IHistoryEndpoint
    {
        internal HistoryEndpoint(XeroHttpClient client)
            : base(client, "/api.xro/2.0/{0}/{1}/history")
        {
            Page(1);
        }

        public IHistoryEndpoint Page(int page)
        {
            AddParameter("page", page);
            return this;
        }

        public override void ClearQueryString()
        {
            base.ClearQueryString();
            Page(1);
        }

        public virtual IEnumerable<History> Get<T, TSource, TSourceResponse>(XeroReadEndpoint<T, TSource, TSourceResponse> sourceEndpoint, TSource source)
            where T : XeroReadEndpoint<T, TSource, TSourceResponse>
            where TSourceResponse : IXeroResponse<TSource>, new()
            where TSource : IHasId
        {
            try
            {
                Client.Where = null;
                Client.Order = null;
                Client.ModifiedSince = null;
                Client.Parameters = null;

                Type sourceEndpointType = sourceEndpoint.GetType();
                PropertyInfo apiEndpointUrlPropertyInfo = sourceEndpointType.GetProperty("ApiEndpointUrl", BindingFlags.Instance | BindingFlags.NonPublic);
                if (apiEndpointUrlPropertyInfo == null)
                    throw new InvalidOperationException("History is not avaialble.");
                string rawApiEndpointUrl = (string)apiEndpointUrlPropertyInfo.GetValue(sourceEndpoint, null);

                return Client.Get<History, HistoryResponse>(string.Format("{0}/{1}/history", rawApiEndpointUrl, source.Id));
            }
            finally
            {
                ClearQueryString();
            }
        }

        public virtual History Put<T, TSource, TSourceRequest, TSourceResponse>(XeroCreateEndpoint<T, TSource, TSourceRequest, TSourceResponse> sourceEndpoint, TSource source, string noteContent)
            where T : XeroReadEndpoint<T, TSource, TSourceResponse>
            where TSourceResponse : IXeroResponse<TSource>, new()
            where TSourceRequest : IXeroRequest<TSource>, new()
            where TSource : IHasId
        {
            var data = new HistoryRequest();
            data.Add(new History {Details = noteContent});
            try
            {
                Client.Where = null;
                Client.Order = null;
                Client.ModifiedSince = null;
                Client.Parameters = null;

                Type sourceEndpointType = sourceEndpoint.GetType();
                PropertyInfo apiEndpointUrlPropertyInfo = sourceEndpointType.GetProperty("ApiEndpointUrl", BindingFlags.Instance | BindingFlags.NonPublic);
                if (apiEndpointUrlPropertyInfo == null)
                    throw new InvalidOperationException("History is not avaialble.");
                string rawApiEndpointUrl = (string)apiEndpointUrlPropertyInfo.GetValue(sourceEndpoint, null);

                return Client.Put<History, HistoryResponse>(string.Format("{0}/{1}/history", rawApiEndpointUrl, source.Id), data).First();
            }
            finally
            {
                ClearQueryString();
            }
        }
    }
}