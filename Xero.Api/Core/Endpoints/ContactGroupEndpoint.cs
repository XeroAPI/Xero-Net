using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Xero.Api.Core.Endpoints.Base;
using Xero.Api.Core.Model;
using Xero.Api.Core.Request;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    
    public class ContactGroupsEndpoint
    {
         private readonly XeroHttpClient _client;

        public ContactGroupsEndpoint(XeroHttpClient client)
        {
            _client = client;
        }

        public ContactGroup Add(ContactGroup contactGroup)
        {
            var endpoint = string.Format("/api.xro/2.0/ContactGroups");

            var groups = HandleResponse(_client
                .Client
                .Put(endpoint, _client.XmlMapper.To(new List<ContactGroup> { contactGroup })))
                .ContactGroups;

            return groups.FirstOrDefault();
        }
        public ContactGroup Update(ContactGroup contactGroup)
        {
            var endpoint = string.Format("/api.xro/2.0/ContactGroups/{0}", contactGroup.Id);

            var groups = HandleResponse(_client
                .Client
                .Post(endpoint, _client.XmlMapper.To(new List<ContactGroup> { contactGroup })))
                .ContactGroups;

            return groups.FirstOrDefault();
        }

        public ContactGroup AssignContacts(ContactGroup contactGroup,List<Contact> contacts)
        {
            var endpoint = string.Format("/api.xro/2.0/ContactGroups/{0}/Contacts", contactGroup.Id);

            var groups= HandleResponse(_client
                .Client
                .Put(endpoint, _client.XmlMapper.To(contacts)))
                .ContactGroups;

            return null;
        }
        public void UnAssignContact(ContactGroup contactGroup, Contact contact)
        {
            var endpoint = string.Format("/api.xro/2.0/ContactGroups/{0}/Contacts/{1}", contactGroup.Id,contact.ContactNumber );

            var groups = HandleResponse(_client
                .Client
                .Delete(endpoint));

        }
        public void EmptyGroup(ContactGroup contactGroup)
        {
            var endpoint = string.Format("/api.xro/2.0/ContactGroups/{0}/Contacts", contactGroup.Id);

            var groups = HandleResponse(_client
                .Client
                .Delete(endpoint));

        }
        
        private ContactGroupsResponse HandleResponse(Infrastructure.Http.Response response)
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = _client.JsonMapper.From<ContactGroupsResponse>(response.Body);
                return result;
            }

            _client.HandleErrors(response);

            return null;
        }
    }
}
