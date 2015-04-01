using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Status
{
    [DataContract(Namespace = "")]
    public enum TrackingOptionStatus
    {
        [EnumMember(Value = "ACTIVE")]
        Active,
      
        [EnumMember(Value = "ARCHIVED")]
        Archived,

        [EnumMember(Value = "DELETED")]
        Deleted
    }
}