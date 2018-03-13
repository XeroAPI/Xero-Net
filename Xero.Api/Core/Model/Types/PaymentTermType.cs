using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Types
{
    [DataContract(Namespace = "")]
    public enum PaymentTermType
    {
        [EnumMember(Value = "OFFOLLOWINGMONTH")]
        FollowingMonth = 1,
        [EnumMember(Value = "DAYSAFTERBILLDATE")]
        AfterBillDate = 2,
        [EnumMember(Value = "OFCURRENTMONTH")]
        CurrentMonth = 3,
        [EnumMember(Value = "DAYSAFTERBILLMONTH")]
        DaysAfterBillMonth = 4,
        [EnumMember(Value = "DAYSAFTERINVOICEMONTH")]
        AfterInvoiceMonth =5
    }
}