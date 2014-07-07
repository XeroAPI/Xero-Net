using System;
using System.Runtime.Serialization;
using Xero.Api.Common;
using Xero.Api.Payroll.America.Model.Types;

namespace Xero.Api.Payroll.America.Model
{
    [DataContract(Namespace = "")]
    public class TimeOffType : HasUpdatedDate
    {
        [DataMember(Name = "TimeOffTypeID")]
        public Guid Id { get; set; }
        
        [DataMember(Name = "TimeOffType")]
        public string Name { get; set; }

        [DataMember]
        public TimeOffCategoryType TimeOffCategory { get; set; }

        [DataMember]
        public string ExpenseAccountCode { get; set; }

        [DataMember]
        public string LiabilityAccountCode { get; set; }

        [DataMember]
        public bool ShowBalanceToEmployee { get; set; }
    }
}