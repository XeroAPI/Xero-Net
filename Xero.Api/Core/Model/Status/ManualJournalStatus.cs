using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Status
{
    [DataContract(Namespace = "")]
    public enum ManualJournalStatus
    {
        Unknown = 0,
        [EnumMember(Value = "DRAFT")]
        Draft,
        [EnumMember(Value = "POSTED")]
        Posted,
        [EnumMember(Value = "DELETED")]
        Deleted,
        [EnumMember(Value = "VOIDED")]
        Voided,
        [EnumMember(Value = "ARCHIVED")]
        Archived
    }
}