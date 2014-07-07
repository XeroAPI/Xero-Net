using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Types
{
    [DataContract(Namespace = "")]
    public enum PaymentTermType
    {
        [EnumMember(Value = "OFFOLLOWINGMONTH")]
        FollowingMonth,
        [EnumMember(Value = "DAYSAFTERBILLDATE")]
        AfterBillDate,
        [EnumMember(Value = "OFCURRENTMONTH")]
        CurrentMonth,
        [EnumMember(Value = "DAYSAFTERINVOICEMONTH")]
        AfterInvoiceMonth
    }
}