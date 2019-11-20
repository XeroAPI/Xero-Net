using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Status
{
    public enum PaymentStatus
    {
        Unknown = 0,
        [EnumMember(Value = "AUTHORISED")]
        Authorised,
        [EnumMember(Value = "DELETED")]
        Deleted
    }
}