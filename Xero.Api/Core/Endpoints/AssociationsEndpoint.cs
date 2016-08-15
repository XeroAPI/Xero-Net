using System;
using System.Collections.Generic;
using System.Net;
using Xero.Api.Core.Model;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public interface IAssociationsEndpoint
    {
        Association Find(Guid fileId, Guid objectId);

        IEnumerable<Association> Find(Guid fileId);

        IEnumerable<Association> FindForObject(Guid objectId);

        Association Create(Association association);

        void Delete(Association association);
    }

    public class AssociationsEndpoint : IAssociationsEndpoint
    {
        public XeroHttpClient Client { get; private set; }

        internal AssociationsEndpoint(XeroHttpClient client)
        {
            Client = client;
        }

        public Association Find(Guid fileId, Guid objectId)
        {
            var endpoint = string.Format("files.xro/1.0/Files/{0}/Associations/{1}", fileId, objectId);
            return HandleAssociationResponse(Client.Client.Get(endpoint, null));
        }

        public IEnumerable<Association> Find(Guid fileId)
        {
            var endpoint = string.Format("files.xro/1.0/Files/{0}/Associations", fileId);
            return HandleAssociationsResponse(Client.Client.Get(endpoint, null));
        }

        public IEnumerable<Association> FindForObject(Guid objectId)
        {
            var endpoint = string.Format("files.xro/1.0/Associations/{0}", objectId);
            return HandleAssociationsResponse(Client.Client.Get(endpoint, null));
        }

        public Association Create(Association association)
        {
            var endpoint = string.Format("files.xro/1.0/Files/{0}/Associations", association.FileId);
            var resp = Client.Client.Post(endpoint, Client.JsonMapper.To(association), "application/json");
            return HandleAssociationResponse(resp);
        }

        public void Delete(Association association)
        {
            var endpoint = string.Format("files.xro/1.0/Files/{0}/Associations/{1}", association.FileId,
                association.ObjectId);
            HandleAssociationResponse(Client.Client.Delete(endpoint));
        }

        private IEnumerable<Association> HandleAssociationsResponse(Infrastructure.Http.Response response)
        {
            if (response.StatusCode == HttpStatusCode.OK
                || response.StatusCode == HttpStatusCode.Created
                || response.StatusCode == HttpStatusCode.Accepted)
            {
                return Client.JsonMapper.From<IEnumerable<Association>>(response.Body);
            }
            Client.HandleErrors(response);
            return null;
        }

        private Association HandleAssociationResponse(Infrastructure.Http.Response response)
        {
            if (response.StatusCode == HttpStatusCode.OK
                || response.StatusCode == HttpStatusCode.Created
                || response.StatusCode == HttpStatusCode.Accepted)
            {
                return Client.JsonMapper.From<Association>(response.Body);
            }
            Client.HandleErrors(response);
            return null;
        }
    }
}