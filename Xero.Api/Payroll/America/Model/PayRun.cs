﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Xero.Api.Payroll.America.Model
{
    [DataContract(Namespace = "")]
    public class PayRun : Common.Model.PayRun
    {
        [DataMember(Name = "PayrollScheduleID")]
        public Guid PayrollScheuleId { get; set; }

        [DataMember]
        public decimal Earnings { get; set; }

        [DataMember]
        public List<PayStub> Paystubs { get; set; }        
    }
}