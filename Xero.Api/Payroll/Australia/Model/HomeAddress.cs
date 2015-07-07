using System.Runtime.Serialization;
using Xero.Api.Payroll.Australia.Model.Types;

namespace Xero.Api.Payroll.Australia.Model
{
    [DataContract(Namespace = "")]
    public class HomeAddress
    {
        [DataMember]
        public string AddressLine1 { get; set; }

        [DataMember]
        public string AddressLine2 { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public State Region { get; set; }

        [DataMember]
        public int PostalCode { get; set; }

        [DataMember]
        public string Country { get; set; }
    }
}