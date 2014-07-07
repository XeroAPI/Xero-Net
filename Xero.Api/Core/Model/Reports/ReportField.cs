using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Reports
{
    [DataContract(Namespace = "")]
    public class ReportField
    {
        [DataMember]
        public string FieldID { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Value { get; set; }

        [DataMember]
        public string Format { get; set; }
    }
}