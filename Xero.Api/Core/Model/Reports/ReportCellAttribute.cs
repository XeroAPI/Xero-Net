using System;
using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Reports
{
	[Serializable]
	[DataContract(Namespace = "", Name = "Attribute")]
    public class ReportCellAttribute
    {
        [DataMember]
        public string Value { get; set; }

        [DataMember]
        public string Id { get; set; }
    }
}