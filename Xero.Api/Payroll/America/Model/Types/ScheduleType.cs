using System.Runtime.Serialization;

namespace Xero.Api.Payroll.America.Model.Types
{
    // I'm sure there are more but I found these in the documentation
    public enum ScheduleType
    {
        [EnumMember(Value = "WEEKLY")]
        Weekly,
        [EnumMember(Value = "BIWEEKLY")]
        Biweekly,
        [EnumMember(Value = "MONTHLY")]
        Monthly,
        [EnumMember(Value = "SEMIMONTHLY")]
        SemiMonthly,
        [EnumMember(Value = "QUARTERLY")]
        Quarterly
    }
}