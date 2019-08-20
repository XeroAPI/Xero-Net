using System.Collections.Generic;
using System.Runtime.Serialization;
using Xero.Api.Common;
using Xero.Api.Core.Model;

namespace Xero.Api.Core.Response
{
    public class OrganisationCisSettingsResponse : XeroResponse<OrganisationCisSetting>
    {
	    [DataMember(Name = "CISSettings")]
		public List<OrganisationCisSetting> OrganisationCisSettings { get; set; }

        public override IList<OrganisationCisSetting> Values
        {
            get { return OrganisationCisSettings; }
        }
    }
}