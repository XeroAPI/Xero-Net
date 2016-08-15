using System.Runtime.Serialization;

namespace Xero.Api.Payroll.Australia.Model.Types
{
    [DataContract(Namespace = "")]
    public enum RateType
    {
        [EnumMember(Value = "FIXEDAMOUNT")]
        Fixed,
        [EnumMember(Value = "MULTIPLE")]
        Multiple,
        [EnumMember(Value = "RATEPERUNIT")]
        RatePerUnit
    }
}