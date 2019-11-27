using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Status
{
    [DataContract(Namespace = "")]
    public enum BankTransactionStatus
    {
        Unknown = 0,
        [EnumMember(Value = "AUTHORISED")]
        Authorised,
        [EnumMember(Value = "DELETED")]
        Deleted,
        [EnumMember(Value = "VOIDED")]
        Voided
    }
}
