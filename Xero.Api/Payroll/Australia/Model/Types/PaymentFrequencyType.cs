using System.Runtime.Serialization;

namespace Xero.Api.Payroll.Australia.Model.Types
{
    [DataContract(Namespace = "")]
    public enum PaymentFrequencyType
    {
        [EnumMember(Value = "WEEKLY")]
        Weekly,
        [EnumMember(Value = "FORTNIGHTLY")]
        Fortnightly,
        [EnumMember(Value = "FOURWEEKLY")]
        FourWeekly,
        [EnumMember(Value = "MONTHLY")]
        Monthly,
        [EnumMember(Value = "TWICEMONTHLY")]
        TwiceMonthly,
        [EnumMember(Value = "QUARTERLY")]
        Quarterly,
        [EnumMember(Value = "YEARLY ")]
        Yearly
    }
}