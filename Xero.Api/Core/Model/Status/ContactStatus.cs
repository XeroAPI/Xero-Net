using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Status
{
    [DataContract(Namespace = "")]
    public enum ContactStatus
    {
        [EnumMember(Value = "ACTIVE")]
        Active,
        //[EnumMember(Value = "DELETED")]
        //Deleted,
        [EnumMember(Value = "ARCHIVED")]
        Archived
    }
}
