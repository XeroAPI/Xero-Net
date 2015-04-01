using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Types
{
    public enum PaymentType
    {
        [EnumMember(Value = "ACCPAYPAYMENT")]
        AccountsPayable,
        [EnumMember(Value = "ACCRECPAYMENT")]
        AccountsReceivable
        [EnumMember(Value = "APCREDITPAYMENT")]
        AccountsPayableCredit,
        [EnumMember(Value = "ARCREDITPAYMENT")]
        AccountsReceivableCredit,
    }
}
