using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Types
{
    [DataContract(Namespace = "")]
    public enum LinkedTransactionType
    {
        [EnumMember(Value = "BILLABLEEXPENSE")]
        BillableExpense
    }
}
