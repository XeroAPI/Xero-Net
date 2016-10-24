using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xero.Api.Core.Endpoints.Base;
using Xero.Api.Core.Model;
using Xero.Api.Core.Request;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public partial interface ITrackingCategoriesEndpoint : IAsyncXeroUpdateEndpoint<TrackingCategoriesEndpoint, TrackingCategory, TrackingCategoriesRequest, TrackingCategoriesResponse>
    {
        Task<List<TrackingCategory>> GetAllAsync(CancellationToken cancellation = default(CancellationToken));
        Task<TrackingCategory> GetByIDAsync(Guid id, CancellationToken cancellation = default(CancellationToken));
        Task<TrackingCategory> DeleteAsync(TrackingCategory trackingCategory, CancellationToken cancellation = default(CancellationToken));
        Task<Option> DeleteTrackingOptionAsync(TrackingCategory trackingCategory, Option option, CancellationToken cancellation = default(CancellationToken));
        Task<TrackingCategory> AddAsync(TrackingCategory trackingCategory, CancellationToken cancellation = default(CancellationToken));
        Task<IAsyncOptionCollection> GetOptionCollectionAsync(Guid id, CancellationToken cancellation = default(CancellationToken));
    }

    public partial class TrackingCategoriesEndpoint : XeroUpdateEndpoint<TrackingCategoriesEndpoint, TrackingCategory, TrackingCategoriesRequest, TrackingCategoriesResponse>, ITrackingCategoriesEndpoint
    {
        public async Task<IAsyncOptionCollection> GetOptionCollectionAsync(Guid id, CancellationToken cancellation = default(CancellationToken))
        {
            var endpoint = string.Format("{0}/{1}", ApiEndpointUrl, id);

            var trackingCat = HandleResponse(await Client.Client.GetAsync(endpoint, null, cancellation)).TrackingCategories.FirstOrDefault();

            var collection = new OptionCollection(Client, trackingCat);

            return collection;
        }

        public async Task<TrackingCategory> GetByIDAsync(Guid id, CancellationToken cancellation = default(CancellationToken))
        {
            var endpoint = string.Format("{0}/{1}", ApiEndpointUrl, id);

            var trackingCat = HandleResponse(await Client.Client.GetAsync(endpoint, null, cancellation)).TrackingCategories.FirstOrDefault();

            return trackingCat;
        }

        public async Task<List<TrackingCategory>> GetAllAsync(CancellationToken cancellation = default(CancellationToken))
        {
            var endpoint = ApiEndpointUrl;

            List<TrackingCategory> trackingCats = HandleResponse(await Client.Client.GetAsync(endpoint, QueryString, cancellation)).TrackingCategories.ToList();

            return trackingCats;
        } 

        public async Task<TrackingCategory> AddAsync(TrackingCategory trackingCategory, CancellationToken cancellation = default(CancellationToken))
        {
            var endpoint = ApiEndpointUrl;

            var groups = HandleResponse(await Client.Client.PutAsync(endpoint, Client.XmlMapper.To(new List<TrackingCategory> { trackingCategory }), cancellation: cancellation)).Values;

            return groups.FirstOrDefault();
        }

        public override async Task<TrackingCategory> UpdateAsync(TrackingCategory trackingCategory, CancellationToken cancellation = default(CancellationToken))
        {
            var endpoint = string.Format("{0}/{1}", ApiEndpointUrl, trackingCategory.Id.ToString());

            trackingCategory.Options = null;

            var groups = HandleResponse(await Client.Client.PostAsync(endpoint, Client.XmlMapper.To(new List<TrackingCategory> { trackingCategory }), cancellation: cancellation)).Values;

            return groups.FirstOrDefault();
        }

        public async Task<TrackingCategory> DeleteAsync(TrackingCategory trackingCategory, CancellationToken cancellation = default(CancellationToken))
        {
            var endpoint = string.Format("{0}/{1}", ApiEndpointUrl, trackingCategory.Id);

            var track = HandleResponse(await Client.Client.DeleteAsync(endpoint, cancellation));

            return track.Values.FirstOrDefault();
        }

        public async Task<Option> DeleteTrackingOptionAsync(TrackingCategory trackingCategory, Option option, CancellationToken cancellation = default(CancellationToken))
        {
            var endpoint = string.Format("{0}/{1}/Options/{2}", ApiEndpointUrl, trackingCategory.Id, option.Id);

            var track = HandleOptionResponse(await Client.Client.DeleteAsync(endpoint, cancellation));

            return track.Values.FirstOrDefault();
        }
    }

    public interface IAsyncOptionCollection : IAsyncXeroUpdateEndpoint<TrackingCategoriesEndpoint, TrackingCategory, TrackingCategoriesRequest, TrackingCategoriesResponse>
    {
        Task<List<Option>> AddAsync(Option option, CancellationToken cancellation = default(CancellationToken));
        Task<List<Option>> AddAsync(List<Option> options, CancellationToken cancellation = default(CancellationToken));
        Task<Option> UpdateOptionAsync(Option option, CancellationToken cancellation = default(CancellationToken));
    }

    public partial class OptionCollection : IAsyncOptionCollection
    {
        public Task<List<Option>> AddAsync(Option option, CancellationToken cancellation = default(CancellationToken))
        {
            List<Option> options = new List<Option>();
 
            options.Add(option);

            return AssignOptionsAsync(_trackingCat, options, cancellation);
        }

        public Task<List<Option>> AddAsync(List<Option> options, CancellationToken cancellation = default(CancellationToken))
        {
            return AssignOptionsAsync(_trackingCat, options, cancellation);
        }

        private async Task<List<Option>> AssignOptionsAsync(TrackingCategory category, List<Option> options, CancellationToken cancellation = default(CancellationToken))
        {
            var endpoint = string.Format("{0}/{1}/Options", ApiEndpointUrl, category.Id);

            var result = HandleResponse(await _client.Client.PutAsync(endpoint, _client.XmlMapper.To(options), cancellation: cancellation)).Values.ToList();

            return result;
        }

        public async Task<Option> UpdateOptionAsync(Option option, CancellationToken cancellation = default(CancellationToken))
        {
            var endpoint = string.Format("{0}/{1}/Options/{2}", ApiEndpointUrl, _trackingCat.Id, option.Id);

            List<Option> Options = new List<Option>();
            Options.Add(option);
            
            var result = HandleResponse(await _client.Client.PostAsync(endpoint, _client.XmlMapper.To(Options), cancellation: cancellation)).Options.FirstOrDefault();

            return result;
        }
    }
}