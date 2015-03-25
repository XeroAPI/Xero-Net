using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Types
{
    [DataContract(Namespace = "")]
    public enum OverpaymentType
    {
        [EnumMember(Value = "SPEND-OVERPAYMENT")]
        SpendOverpayment,
        [EnumMember(Value = "RECEIVE-OVERPAYMENT")]
        ReceiveOverpayment
    }
}