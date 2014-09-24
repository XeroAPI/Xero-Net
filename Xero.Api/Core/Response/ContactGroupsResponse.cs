using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xero.Api.Common;
using Xero.Api.Core.Model;

namespace Xero.Api.Core.Response
{
    public class ContactGroupsResponse : XeroResponse<ContactGroup>
    {
        public List<ContactGroup> ContactGroups { get; set; }

        public override IList<ContactGroup> Values
        {
            get { return ContactGroups; }
        }
    }
}
