using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Payroll.Australia.Model;

namespace Xero.Api.Payroll.Australia.Request
{
    [DataContract(Namespace = "", Name = "PayItems")]
    public class PayItemsRequest : IXeroRequest<PayItems>
    {
        [DataMember(EmitDefaultValue = false)]
        public List<EarningsRate> EarningsRates { get { return PayItems.EarningsRates; } }

        [DataMember(EmitDefaultValue = false)]
        public List<DeductionType> DeductionTypes { get { return PayItems.DeductionTypes; } }

        [DataMember(EmitDefaultValue = false)]
        public List<LeaveType> LeaveTypes { get { return PayItems.LeaveTypes; } }

        [DataMember(EmitDefaultValue = false)]
        public List<ReimbursementType> ReimbursementTypes { get { return PayItems.ReimbursementTypes; } }

        private PayItems PayItems { get; set; }
        
        public IList<PayItems> Items { get { return new[] { PayItems }; } }

        public void Add(PayItems value)
        {
            PayItems = value;
        }

        public void AddRange(IEnumerable<PayItems> value)
        {
            PayItems = value.FirstOrDefault();
        }
    }
}