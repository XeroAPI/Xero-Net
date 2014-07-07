using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Status
{
    [DataContract(Namespace = "")]
    public enum ExpenseClaimStatus
    {
        [EnumMember(Value= "SUBMITTED")]
        Submitted,
        [EnumMember(Value = "AUTHORISED")]
        Authorised,
        [EnumMember(Value = "PAID")]
        Paid,
        [EnumMember(Value = "VOIDED")]
        Voided
    }
}