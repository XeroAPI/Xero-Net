using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Status
{
    [DataContract(Namespace = "")]
    public enum PurchaseOrderStatus
    {
        [EnumMember(Value = "DRAFT")]
        Draft,
        [EnumMember(Value = "SUBMITTED")]
        Submitted,
        [EnumMember(Value = "AUTHORISED")]
        Authorised,
        [EnumMember(Value = "BILLED")]
        Billed,
        [EnumMember(Value = "DELETED")]
        Deleted
    }
}