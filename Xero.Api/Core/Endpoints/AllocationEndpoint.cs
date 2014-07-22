using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using Xero.Api.Common;
using Xero.Api.Core.Model;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public class AllocationsEndpoint
    {
        private readonly XeroHttpClient _client;
        
        public AllocationsEndpoint(XeroHttpClient client)
        {
            _client = client;
        }

        public Allocation Add(Allocation allocation)
        {
            var endpoint = string.Format("/api.xro/2.0/CreditNotes/{0}/Allocations", allocation.CreditNote.Id);

            var allocations = HandleResponse(_client
                .Client
                .Put(endpoint, _client.XmlMapper.To(new List<Allocation>{allocation} )))
                .Allocations;

            return allocations.FirstOrDefault();
        }

        private AllocationsResponse HandleResponse(Infrastructure.Http.Response response)
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = _client.JsonMapper.From<AllocationsResponse>(response.Body);
                return result;
            }

            _client.HandleErrors(response);

            return null;
        }
    }

    public class AllocationsResponse : XeroResponse<Allocation>
    {
        public List<Allocation> Allocations { get; set; }

        public override IList<Allocation> Values
        {
            get { return Allocations; }
        }
    }     
}
