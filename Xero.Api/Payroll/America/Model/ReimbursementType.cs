using System;
using System.Runtime.Serialization;
using Xero.Api.Common;

namespace Xero.Api.Payroll.America.Model
{
    [DataContract(Namespace = "")]
    public class ReimbursementType : HasUpdatedDate
    {
        [DataMember(Name = "ReimbursementTypeID")]
        public Guid Id { get; set; }

        [DataMember(Name = "ReimbursementType")]
        public string Name { get; set; }

        [DataMember]
        public string ExpenseOrLiabilityAccountCode { get; set; }
    }
}