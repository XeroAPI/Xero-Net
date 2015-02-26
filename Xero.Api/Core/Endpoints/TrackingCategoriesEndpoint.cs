using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
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
    public class TrackingCategoriesEndpoint : XeroUpdateEndpoint<TrackingCategoriesEndpoint, TrackingCategory, TrackingCategoriesRequest, TrackingCategoriesResponse>
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

        public OptionCollection this[Guid id]
        {
            get
            {
                var endpoint = string.Format("/api.xro/2.0/TrackingCategories/{0}", id);

                var trackingCat = HandleResponse(Client.Client.Get(endpoint, null)).TrackingCategories.FirstOrDefault();

                var collection = new OptionCollection(Client, trackingCat);

                return collection;
            }
        }

        public List<TrackingCategory> GetAll()
        {
            var endpoint = string.Format("/api.xro/2.0/TrackingCategories");

            List<TrackingCategory> trackingCats = HandleResponse(Client.Client.Get(endpoint, QueryString)).TrackingCategories.ToList();

            return trackingCats;
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
            var endpoint = string.Format("/api.xro/2.0/TrackingCategories/{0}", trackingCategory.Id.ToString());

            trackingCategory.Options = null;

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

    public class OptionCollection :
        XeroUpdateEndpoint<TrackingCategoriesEndpoint, TrackingCategory, TrackingCategoriesRequest, TrackingCategoriesResponse>
    {
        public TrackingCategory _trackingCat;
        private XeroHttpClient _client;

        public OptionCollection(XeroHttpClient client, TrackingCategory trackingCat)
            : base(client, "/api.xro/2.0/TrackingCategories")
        {
            _trackingCat = trackingCat;
            _client = client;
        }

        public TrackingCategory Add(Option option)
        {
            List<Option> options = new List<Option>();
 
            options.Add(option);

            AssignOptions(_trackingCat, options);

            return _trackingCat;
        }

        public TrackingCategory Add(List<Option> options)
        {
            AssignOptions(_trackingCat, options);

            return _trackingCat;
        }

        private void AssignOptions(TrackingCategory category, List<Option> options)
        {
            var endpoint = string.Format("/api.xro/2.0/trackingcategories/{0}/options", category.Id);

            HandleResponse(_client
                 .Client
                 .Put(endpoint, _client.XmlMapper.To(options)));
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

        public TrackingCategory UpdateOption(Option option)
        {
            var endpoint = string.Format("/api.xro/2.0/trackingcategories/{0}/options/{1}", _trackingCat.Id, option.Id);

            option.Id = Guid.Empty;

            return HandleResponse(_client
                 .Client
                 .Post(endpoint, _client.XmlMapper.To(option))).TrackingCategories.FirstOrDefault();
        }
    }
}