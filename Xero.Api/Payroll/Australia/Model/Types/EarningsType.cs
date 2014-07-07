using System.Runtime.Serialization;

namespace Xero.Api.Payroll.Australia.Model.Types
{
    [DataContract(Namespace = "")]
    public enum EarningsType
    {
        [EnumMember(Value = "ORDINARYTIMEEARNINGS")]
        OrdinaryTimeEarnings,
        [EnumMember(Value = "OVERTIMEEARNINGS")]
        OverTimeEarnings,
        [EnumMember(Value = "ALLOWANCE")]
        Allowance,
        [EnumMember(Value = "COMMISSION")]
        Commission,
        [EnumMember(Value = "BONUS")]
        Bonus,
        [EnumMember(Value = "BACKPAY")]
        BackPay
    }
}