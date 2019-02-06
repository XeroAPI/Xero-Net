using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Reports
{
	[Serializable]
	[DataContract(Namespace = "", Name = "Cell")]
    public class ReportCell
    {
        [DataMember]
        public string Value { get; set; }

        [DataMember]
        public List<ReportCellAttribute> Attributes { get; set; }
    }
}