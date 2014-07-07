using System;
using System.Runtime.Serialization;
using Xero.Api.Payroll.Australia.Model.Types;

namespace Xero.Api.Payroll.Australia.Model
{
    [DataContract(Namespace = "")]
    public class SuperLine
    {
        [DataMember(Name = "SuperMembershipID")]
        public Guid SuperMembershipId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public SuperannuationCalculationType CalculationType { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public SuperannuationContributionType ContributionType { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int ExpenseAccountCode { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int LiabilityAccountCode { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public decimal? Amount { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public decimal? Percentage { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public decimal? MinimumMonthlyEarnings { get; set; }        
    }
}