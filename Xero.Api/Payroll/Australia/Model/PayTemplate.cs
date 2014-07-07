using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Xero.Api.Payroll.Australia.Model
{
    [DataContract(Namespace = "")]
    public class PayTemplate
    {
        [DataMember]
        public List<EarningsLine> EarningsLines { get; set; }

        [DataMember]
        public List<DeductionLine> DeductionLines { get; set; }

        [DataMember]
        public List<ReimbursementLine> ReimbursementLines { get; set; }

        [DataMember]
        public List<SuperLine> SuperLines { get; set; }

        [DataMember]
        public List<LeaveLine> LeaveLines { get; set; } 
    }
}