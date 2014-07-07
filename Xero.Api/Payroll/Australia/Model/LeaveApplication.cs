using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Xero.Api.Common;

namespace Xero.Api.Payroll.Australia.Model
{
    [DataContract(Namespace = "")]
    public class LeaveApplication : HasUpdatedDate
    {
        [DataMember(Name = "LeaveApplicationID", EmitDefaultValue = false)]
        public Guid Id { get; set; }

        [DataMember(Name = "EmployeeID")]
        public Guid EmployeeId { get; set; }

        [DataMember(Name = "LeaveTypeID", EmitDefaultValue = false)]
        public Guid LeaveTypeId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Title { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public DateTime? StartDate { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public DateTime? EndDate { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<LeavePeriod> LeavePeriods { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Description { get; set; }
    }
}
