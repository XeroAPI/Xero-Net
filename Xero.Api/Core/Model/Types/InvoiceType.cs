using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Types
{
    [DataContract(Namespace = "")]
    public enum InvoiceType
    {
        Unknown = 0,
        [EnumMember(Value = "ACCPAY")]
        AccountsPayable = 1,
        [EnumMember(Value = "ACCREC")]
        AccountsReceivable
    }
}