using System;
using System.Runtime.Serialization;
using Xero.Api.Common;
using Xero.Api.Payroll.Common.Model;

namespace Xero.Api.Payroll.Australia.Model
{
    [DataContract(Namespace = "")]
    public class TimesheetLine : HasUpdatedDate
    {
        [DataMember(Name = "EarningsRateID")]
        public Guid EarningsRateId { get; set; }

        [DataMember(Name = "TrackingItemID", EmitDefaultValue = false)]
        public Guid TrackingItemID { get; set; }

        [DataMember]
        public NumberOfUnits NumberOfUnits { get; set; }
    }
}
