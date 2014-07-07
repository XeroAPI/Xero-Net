using System.Runtime.Serialization;
using Xero.Api.Core.Model.Types;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "")]
    public class Address
    {
        [DataMember]
        public AddressType AddressType { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string AddressLine1 { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string AddressLine2 { get; set; }
        
        [DataMember(EmitDefaultValue = false)]
        public string AddressLine3 { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string AddressLine4 { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string City { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Region { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string PostalCode { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Country { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string AttentionTo { get; set; }
    }
}
