using System;
using System.Runtime.Serialization;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "")]
    public class Allocation
    {
        [DataMember(EmitDefaultValue = false)]
        public decimal AppliedAmount { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public DateTime Date { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Invoice Invoice { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public decimal Amount { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public CreditNote CreditNote { get; set; }
    }    
}