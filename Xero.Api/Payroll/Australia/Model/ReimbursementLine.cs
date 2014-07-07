using System;
using System.Runtime.Serialization;

namespace Xero.Api.Payroll.Australia.Model
{
    [DataContract(Namespace = "")]
    public class ReimbursementLine
    {
        [DataMember(Name = "ReimbursementTypeID")]
        public Guid Id { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public decimal? Amount { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Description { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string ExpenseAccount { get; set; }
    }
}