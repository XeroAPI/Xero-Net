using System.Runtime.Serialization;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "", Name = "Allocation")]
    public class CreditNoteAllocation : AllocationBase
    {
        [DataMember(EmitDefaultValue = false)]
        public CreditNote CreditNote { get; set; }
    }
}