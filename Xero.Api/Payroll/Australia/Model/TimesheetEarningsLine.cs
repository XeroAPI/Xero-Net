using System;
using System.Runtime.Serialization;

namespace Xero.Api.Payroll.Australia.Model
{
    [DataContract(Namespace = "")]
    public class TimesheetEarningsLine
    {
        [DataMember(Name = "EarningsRateID")]
        public Guid EarningsRateId { get; set; }

        [DataMember]
        public decimal? RatePerUnit { get; set; }

        [DataMember]
        public decimal? Amount { get; set; }
    }
}