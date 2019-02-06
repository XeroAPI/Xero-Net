using System;
using System.Runtime.Serialization;

namespace Xero.Api.Core.Model
{
	[Serializable]
	public class OrganisationCisSetting
    {
        [DataMember(Name = "CISContractorEnabled")]
        public bool CisContractorEnabled { get; set; }

        [DataMember(Name = "CISSubContractorEnabled")]
        public bool CisSubContractorEnabled { get; set; }
    }
}