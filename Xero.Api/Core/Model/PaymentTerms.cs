using System.Runtime.Serialization;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "")]
    public class PaymentTerms
    {
        [DataMember]
        public Terms Bills { get; set; }

        [DataMember]
        public Terms Sales { get; set; }
    }
}