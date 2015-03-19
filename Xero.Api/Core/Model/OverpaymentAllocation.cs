using System.Runtime.Serialization;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "", Name = "Allocation")]
    public class OverpaymentAllocation : AllocationBase
    {
        [DataMember(EmitDefaultValue = false)]
        public Overpayment Overpayment { get; set; }
    }
}