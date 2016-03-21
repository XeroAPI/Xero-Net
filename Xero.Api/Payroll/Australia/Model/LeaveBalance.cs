using System;
using System.Runtime.Serialization;
using Xero.Api.Payroll.Australia.Model.Types;

namespace Xero.Api.Payroll.Australia.Model
{
    [DataContract(Namespace = "")]
    public class LeaveBalance
    {
        [DataMember(EmitDefaultValue = false)]
        public string LeaveName { get; set; }

        [DataMember(Name = "LeaveTypeID")]
        public Guid LeaveTypeId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public decimal NumberOfUnits { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string TypeOfUnits { get; set; }
    }
}