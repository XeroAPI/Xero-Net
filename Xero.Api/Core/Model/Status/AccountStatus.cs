using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Status
{
    [DataContract(Namespace = "")]
    public enum AccountStatus
    {
        [EnumMember(Value = "ACTIVE")]
        Active = 1,
        [EnumMember(Value = "ARCHIVED")]
        Archived = 2
    }
}