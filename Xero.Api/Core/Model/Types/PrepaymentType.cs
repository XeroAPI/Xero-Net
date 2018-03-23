using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Types
{
    [DataContract(Namespace = "")]
    public enum PrepaymentType
    {
        Unknown = 0,
        [EnumMember(Value = "SPEND-PREPAYMENT")]
        SpendPrepayment = 1,
        [EnumMember(Value = "RECEIVE-PREPAYMENT")]
        ReceivePrepayment = 2
    }
}