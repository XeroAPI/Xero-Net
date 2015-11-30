using System;
using System.Runtime.Serialization;
using Xero.Api.Common;
using Xero.Api.Payroll.Common.Model;

namespace Xero.Api.Payroll.America.Model
{
    [DataContract(Namespace = "")]
    public class TimesheetLine : HasUpdatedDate
    {
        [DataMember(Name = "EarningsTypeID")]
        public Guid EarningsTypeId { get; set; }

        [DataMember(Name = "TrackingItemID")]
        public Guid TrackingItemID { get; set; }

        [DataMember]
        public NumberOfUnits NumberOfUnits { get; set; }
    }
}