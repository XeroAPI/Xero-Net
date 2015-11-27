﻿using System.Collections.Generic;
using System.Runtime.Serialization;
using Xero.Api.Payroll.Common.Model;

namespace Xero.Api.Payroll.Australia.Model
{
    [DataContract(Namespace = "")]
    public class Settings
    {
        [DataMember(EmitDefaultValue = false)]
        public List<Account> Accounts { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<TrackingCategory> TrackingCategories { get; set; }

        [DataMember]
        public int DaysInPayrollYear { get; set; }

        public IList<Settings> Values { get; private set; }
    }
}
