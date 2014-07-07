using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Status
{
    [DataContract(Namespace = "")]
    public enum BankTransactionStatus
    {
        [EnumMember(Value = "AUTHORISED")]
        Authorised,
        [EnumMember(Value = "DELETED")]
        Deleted
    }
}
