using System;
using System.Runtime.Serialization;

namespace Xero.Api.Payroll.Common.Model
{
	[Serializable]
	[DataContract(Namespace = "")]
    public class PayrollSettingsTrackingCategories
    {
        [DataMember(EmitDefaultValue = false)]
        public TrackingCategory EmployeeGroups { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public TrackingCategory TimesheetCategories { get; set; }

    }
}
