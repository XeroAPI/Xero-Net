using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xero.Api.Core.Model;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public partial interface IAssociationsEndpoint
    {
        Task<Association> FindAsync(Guid fileId, Guid objectId, CancellationToken cancellation = default(CancellationToken));

        Task<IList<Association>> FindAsync(Guid fileId, CancellationToken cancellation = default(CancellationToken));

        Task<IList<Association>> FindForObjectAsync(Guid objectId, CancellationToken cancellation = default(CancellationToken));

        Task<Association> CreateAsync(Association association, CancellationToken cancellation = default(CancellationToken));

        Task DeleteAsync(Association association, CancellationToken cancellation = default(CancellationToken));
    }

    public partial class AssociationsEndpoint : IAssociationsEndpoint
    {
        public async Task<Association> FindAsync(Guid fileId, Guid objectId, CancellationToken cancellation = default(CancellationToken))
        {
            var endpoint = string.Format("files.xro/1.0/Files/{0}/Associations/{1}", fileId, objectId);
            return HandleAssociationResponse(await Client.Client.GetAsync(endpoint, null, cancellation));
        }

        public async Task<IList<Association>> FindAsync(Guid fileId, CancellationToken cancellation = default(CancellationToken))
        {
            var endpoint = string.Format("files.xro/1.0/Files/{0}/Associations", fileId);
            return HandleAssociationsResponseList(await Client.Client.GetAsync(endpoint, null, cancellation));
        }

        public async Task<IList<Association>> FindForObjectAsync(Guid objectId, CancellationToken cancellation = default(CancellationToken))
        {
            var endpoint = string.Format("files.xro/1.0/Associations/{0}", objectId);
            return HandleAssociationsResponseList(await Client.Client.GetAsync(endpoint, null, cancellation));
        }

        public async Task<Association> CreateAsync(Association association, CancellationToken cancellation = default(CancellationToken))
        {
            var endpoint = string.Format("files.xro/1.0/Files/{0}/Associations", association.FileId);
            var resp = await Client.Client.PostAsync(endpoint, Client.JsonMapper.To(association), "application/json", cancellation: cancellation);
            return HandleAssociationResponse(resp);
        }

        public async Task DeleteAsync(Association association, CancellationToken cancellation = default(CancellationToken))
        {
            var endpoint = string.Format("files.xro/1.0/Files/{0}/Associations/{1}", association.FileId, association.ObjectId);
            HandleAssociationResponse(await Client.Client.DeleteAsync(endpoint, cancellation));
        }

        private IList<Association> HandleAssociationsResponseList(Infrastructure.Http.Response response)
        {
            if (response.StatusCode == HttpStatusCode.OK
                || response.StatusCode == HttpStatusCode.Created
                || response.StatusCode == HttpStatusCode.Accepted)
            {
                return Client.JsonMapper.From<IList<Association>>(response.Body);
            }

            Client.HandleErrors(response);
            return null;
        }
    }
}