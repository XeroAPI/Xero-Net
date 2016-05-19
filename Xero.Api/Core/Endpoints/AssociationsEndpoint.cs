using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using Xero.Api.Core.Endpoints.Base;
using Xero.Api.Core.Model;
using Xero.Api.Core.Request;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;
using Xero.Api.Infrastructure.Interfaces;

namespace Xero.Api.Core.Endpoints {

    public class AssociationsEndpoint {

        public XeroHttpClient Client { get; }

        internal AssociationsEndpoint(XeroHttpClient client) {
            Client = client;
        }

        public Association Find(Guid fileId, Guid objectId) {
            var endpoint = $"files.xro/1.0/Files/{fileId}/Associations/{objectId}";
            return HandleAssociationResponse(Client.Client.Get(endpoint, null));
        }

        public IEnumerable<Association> Find(Guid fileId) {
            var endpoint = $"files.xro/1.0/Files/{fileId}/Associations";
            return HandleAssociationsResponse(Client.Client.Get(endpoint, null));
        }

        public IEnumerable<Association> FindForObject(Guid objectId) {
            var endpoint = $"files.xro/1.0/Associations/{objectId}";
            return HandleAssociationsResponse(Client.Client.Get(endpoint, null));
        }

        public Association Create(Association association) {
            var endpoint = $"files.xro/1.0/Files/{association.FileId}/Associations";
            var resp = Client.Client.Post(endpoint, Client.JsonMapper.To(association), "application/json");
            return HandleAssociationResponse(resp);
        }

        public void Delete(Association association) {
            var endpoint = $"files.xro/1.0/Files/{association.FileId}/Associations/{association.ObjectId}";
            HandleAssociationResponse(Client.Client.Delete(endpoint));
        }
        
        private IEnumerable<Association> HandleAssociationsResponse(Infrastructure.Http.Response response) {
            if (response.StatusCode == HttpStatusCode.OK 
                || response.StatusCode == HttpStatusCode.Created
                || response.StatusCode == HttpStatusCode.Accepted) {

                return Client.JsonMapper.From<IEnumerable<Association>>(response.Body);
            }
            Client.HandleErrors(response);
            return null;
        }

        private Association HandleAssociationResponse(Infrastructure.Http.Response response) {
            if (response.StatusCode == HttpStatusCode.OK
                || response.StatusCode == HttpStatusCode.Created
                || response.StatusCode == HttpStatusCode.Accepted) {
                
                return Client.JsonMapper.From<Association>(response.Body);
            }
            Client.HandleErrors(response);
            return null;
        }
    }

}