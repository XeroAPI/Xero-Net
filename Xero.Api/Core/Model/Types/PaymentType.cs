using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Types
{
    public enum PaymentType
    {
        [EnumMember(Value = "ACCPAYPAYMENT")]
        AccountsPayable = 1,
        [EnumMember(Value = "ACCRECPAYMENT")]
        AccountsReceivable = 2,
        [EnumMember(Value = "APCREDITPAYMENT")]
        AccountsPayableCredit = 3,
        [EnumMember(Value = "ARCREDITPAYMENT")]
        AccountsReceivableCredit = 4,
        [EnumMember(Value = "ARPREPAYMENTPAYMENT")]
        AccountsReceivablePrepayment = 5,
        [EnumMember(Value = "APPREPAYMENTPAYMENT")]
        AccountsPayablePrepayment = 6,
        [EnumMember(Value = "AROVERPAYMENTPAYMENT")]
        AccountsReceivableOverpayment = 7,
        [EnumMember(Value = "APOVERPAYMENTPAYMENT")]
        AccountsPayableOverpayment = 8,
    }
}
