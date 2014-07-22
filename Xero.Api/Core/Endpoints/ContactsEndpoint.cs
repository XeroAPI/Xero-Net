using Xero.Api.Core.Endpoints.Base;
using Xero.Api.Core.Model;
using Xero.Api.Core.Request;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public class ContactsEndpoint
        : XeroUpdateEndpoint<ContactsEndpoint, Contact, ContactsRequest, ContactsResponse>
    {
        internal ContactsEndpoint(XeroHttpClient client)
            : base(client, "/api.xro/2.0/Contacts")
        {
            Page(1);
        }

        public ContactsEndpoint Page(int page)
        {
            AddParameter("page", page);
            return this;
        }

        public override void ClearQueryString()
        {
            base.ClearQueryString();
            Page(1);
        }

        public ContactsEndpoint IncludeArchived(bool include)
        {
            if (include)
            {
                AddParameter("includeArchived", true);
            }

            return this;
        }
    }
}