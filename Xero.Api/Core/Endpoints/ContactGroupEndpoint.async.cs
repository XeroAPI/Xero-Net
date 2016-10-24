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
    public partial interface IContactGroupsEndpoint :
        IAsyncXeroUpdateEndpoint<ContactGroupsEndpoint, ContactGroup, ContactGroupsRequest, ContactGroupsResponse>
    {
        Task<IAsyncContactCollection> GetCollectionAsync(Guid guid, CancellationToken cancellation = default(CancellationToken));
        Task<ContactGroup> AddAsync(ContactGroup contactGroup, CancellationToken cancellation = default(CancellationToken));
    }

    public partial class ContactGroupsEndpoint : XeroUpdateEndpoint<ContactGroupsEndpoint,ContactGroup,ContactGroupsRequest,ContactGroupsResponse>,
        IContactGroupsEndpoint
    {
        public async Task<IAsyncContactCollection> GetCollectionAsync(Guid guid, CancellationToken cancellation = default(CancellationToken))
        {
            var endpoint = string.Format("/api.xro/2.0/ContactGroups/{0}",guid);

            var group = HandleResponse(await Client.Client.GetAsync(endpoint, null, cancellation)).ContactGroups.SingleOrDefault();

            var collection = new ContactCollection(Client, group);

            return collection;
        }

        public async Task<ContactGroup> AddAsync(ContactGroup contactGroup, CancellationToken cancellation = default(CancellationToken))
        {
            var endpoint = string.Format("/api.xro/2.0/ContactGroups");

            var groups = HandleResponse(await Client.Client.PutAsync(endpoint, Client.XmlMapper.To(new List<ContactGroup> { contactGroup }), cancellation: cancellation)).ContactGroups;

            return groups.FirstOrDefault();
        }
    }

    public interface IAsyncContactCollection : IAsyncXeroUpdateEndpoint<ContactGroupsEndpoint, ContactGroup, ContactGroupsRequest, ContactGroupsResponse>
    {
        Task ClearAsync(CancellationToken cancellation = default(CancellationToken));
        Task AddAsync(Contact contact, CancellationToken cancellation = default(CancellationToken));
        Task AddRangeAsync(List<Contact> contacts, CancellationToken cancellation = default(CancellationToken));
        Task RemoveAsync(Guid guid, CancellationToken cancellation = default(CancellationToken));
    }

    public partial class ContactCollection : XeroUpdateEndpoint<ContactGroupsEndpoint, ContactGroup, ContactGroupsRequest, ContactGroupsResponse>, IAsyncContactCollection
    {
        public async Task ClearAsync(CancellationToken cancellation = default(CancellationToken))
        {
            var endpoint = string.Format("/api.xro/2.0/ContactGroups/{0}/Contacts", _group.Id);
            HandleResponse(await Client.Client.DeleteAsync(endpoint, cancellation));
        }

        public Task AddAsync(Contact contact, CancellationToken cancellation = default(CancellationToken))
        {
            var contactList = new List<Contact>();

            contactList.Add(contact);
            
            return AssignContactsAsync(_group, contactList, cancellation);
        }

        public Task AddRangeAsync(List<Contact> contacts, CancellationToken cancellation = default(CancellationToken))
        {
            return AssignContactsAsync(_group, contacts, cancellation);
        }

        public Task RemoveAsync(Guid guid, CancellationToken cancellation = default(CancellationToken))
        {
            return UnAssignContactAsync(_group, guid, cancellation);
        }

        private async Task UnAssignContactAsync(ContactGroup contactGroup, Guid contactId, CancellationToken cancellation = default(CancellationToken))
        {
            var endpoint = string.Format("/api.xro/2.0/ContactGroups/{0}/Contacts/{1}", contactGroup.Id, contactId);
            HandleResponse(await Client.Client.DeleteAsync(endpoint, cancellation));
        }

        private async Task AssignContactsAsync(ContactGroup contactGroup, List<Contact> contacts, CancellationToken cancellation = default(CancellationToken))
        {
            var endpoint = string.Format("/api.xro/2.0/ContactGroups/{0}/Contacts", contactGroup.Id);
            HandleResponse(await _client.Client.PutAsync(endpoint, _client.XmlMapper.To(contacts), cancellation: cancellation));
        }
    }
}
