﻿using System;
using System.Runtime.Serialization;
using Xero.Api.Common;

namespace Xero.Api.Payroll.Common.Model
{
    [DataContract(Namespace = "")]
    public class TimesheetLine : HasUpdatedDate
    {
        [DataMember(Name = "EarningsRateID")]
        public Guid EarningsRateId { get; set; }

        [DataMember(Name = "TrackingItemID")]
        public Guid TrackingItemID { get; set; }

        [DataMember]
        public NumberOfUnits NumberOfUnits { get; set; }        
    }
}