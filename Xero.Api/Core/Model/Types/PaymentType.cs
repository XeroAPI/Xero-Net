using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Types
{
    public enum PaymentType
    {
        [EnumMember(Value = "ACCPAYPAYMENT")]
        AccountsPayable,
        [EnumMember(Value = "ACCRECPAYMENT")]
        AccountsRecievable
    }
}
