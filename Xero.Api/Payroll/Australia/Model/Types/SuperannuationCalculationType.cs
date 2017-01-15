using System.Runtime.Serialization;

namespace Xero.Api.Payroll.Australia.Model.Types
{
    [DataContract(Namespace = "")]
    public enum SuperannuationCalculationType
    {
        [EnumMember(Value = "STATUTORY")]
        Statutory,
        [EnumMember(Value = "FIXEDAMOUNT")]
        FixedAmount,
        [EnumMember(Value = "PERCENTAGEOFEARNINGS")]
        PercentageOfEarnings
    }
}