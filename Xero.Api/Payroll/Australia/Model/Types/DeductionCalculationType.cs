using System.Runtime.Serialization;

namespace Xero.Api.Payroll.Australia.Model.Types
{
    [DataContract(Namespace = "")]
    public enum DeductionCalculationType
    {
        [EnumMember(Value = "FIXEDAMOUNT")]
        FixedAmount,
        [EnumMember(Value = "PRETAX")]
        PreTax,
        [EnumMember(Value = "POSTTAX")]
        PostTax
    }
}
