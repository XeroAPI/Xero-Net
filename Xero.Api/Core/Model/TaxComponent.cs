using System.Runtime.Serialization;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "")]
    public class TaxComponent
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public decimal Rate { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public bool? IsCompound { get; set; }
    }
}
