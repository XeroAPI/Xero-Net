using System.Collections.Generic;
using Xero.Api.Common;
using Xero.Api.Core.Model;

namespace Xero.Api.Core.Response
{
    public class OrganisationResponse : XeroResponse<Organisation> 
    {
        public List<Organisation> Organisations { get; set; }

        public override IList<Organisation> Values
        {
            get { return Organisations; }
        }
    }
}