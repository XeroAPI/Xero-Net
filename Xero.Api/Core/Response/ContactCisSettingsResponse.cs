using System.Collections.Generic;
using System.Runtime.Serialization;
using Xero.Api.Common;
using Xero.Api.Core.Model;

namespace Xero.Api.Core.Response
{
	[DataContract(Namespace = "")]
    public class ContactCisSettingsResponse : XeroResponse<ContactCisSetting>
    {
	    [DataMember(Name = "CISSettings")]
		public List<ContactCisSetting> ContactCisSettings { get; set; }

        public override IList<ContactCisSetting> Values
        {
            get { return ContactCisSettings; }
        }
    }
}