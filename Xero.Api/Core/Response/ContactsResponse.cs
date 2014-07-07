using System.Collections.Generic;
using Xero.Api.Common;
using Xero.Api.Core.Model;

namespace Xero.Api.Core.Response
{
    public class ContactsResponse : XeroResponse<Contact>
    {
        public List<Contact> Contacts { get; set; }

        public override IList<Contact> Values
        {
            get { return Contacts; }
        }
    }
}