using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Xero.Api.Common;
using Xero.Api.Core.Endpoints.Base;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Setup;
using Xero.Api.Core.Request;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public class TrackingCategoriesEndpoint : XeroReadEndpoint<TrackingCategoriesEndpoint, TrackingCategory, TrackingCategoriesResponse>
    {
        public TrackingCategoriesEndpoint(XeroHttpClient client) :
            base(client, "/api.xro/2.0/TrackingCategories")
        {            
        }

        public TrackingCategoriesEndpoint IncludeArchived(bool include)
        {
            if (include)
            {
                AddParameter("includeArchived", true);
            }

            return this;
        }

        public List<Option> this[Guid id]
        {
            get
            {
                var endpoint = string.Format("/api.xro/2.0/TrackingCategories/{0}", id);

                var options = Client.Client.Get(endpoint, null);

                return null;
            }
        }

        public TrackingCategory Add(TrackingCategory trackingCategory)
        {
            var endpoint = string.Format("/api.xro/2.0/TrackingCategories");

            var groups = HandleResponse(Client
                .Client
                .Put(endpoint, Client.XmlMapper.To(new List<TrackingCategory> { trackingCategory })))
                .Values;

            return groups.FirstOrDefault();
        }

        public TrackingCategory Update(TrackingCategory trackingCategory)
        {
            var endpoint = string.Format("/api.xro/2.0/TrackingCategories");

            var groups = HandleResponse(Client
                .Client
                .Post(endpoint, Client.XmlMapper.To(new List<TrackingCategory> { trackingCategory })))
                .Values;

            return groups.FirstOrDefault();
        }

        private TrackingCategoriesResponse HandleResponse(Infrastructure.Http.Response response)
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = Client.JsonMapper.From<TrackingCategoriesResponse>(response.Body);
                return result;
            }

            Client.HandleErrors(response);

            return null;
        }
    }
}