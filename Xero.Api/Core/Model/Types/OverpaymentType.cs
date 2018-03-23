using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Types
{
    [DataContract(Namespace = "")]
    public enum OverpaymentType
    {
        Unknown = 0,
        [EnumMember(Value = "SPEND-OVERPAYMENT")]
        SpendOverpayment = 1,
        [EnumMember(Value = "RECEIVE-OVERPAYMENT")]
        ReceiveOverpayment = 2
    }
}