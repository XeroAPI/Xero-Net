using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Xero.Api.Payroll.America.Model
{
    [DataContract(Namespace = "")]
    public class PayItems
    {
        [DataMember]
        public List<EarningsType> EarningsTypes { get; set; }

        [DataMember]
        public List<BenefitType> BenefitTypes { get; set; }

        [DataMember]
        public List<DeductionType> DeductionTypes { get; set; }

        [DataMember]
        public List<ReimbursementType> ReimbursementTypes { get; set; }

        [DataMember]
        public List<TimeOffType> TimeOffTypes { get; set; }
    }
}