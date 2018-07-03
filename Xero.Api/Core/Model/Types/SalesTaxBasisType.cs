using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Types
{
    [DataContract]
    public enum SalesTaxBasisType
    {
        [EnumMember(Value = "NONE")]
        None,
        [EnumMember(Value = "ACCRUALS")]
        Accurals=1,
        [EnumMember(Value = "ACCRUAL")]
        Accural = 1,
        [EnumMember(Value = "CASH")]
        Cash,
        [EnumMember(Value = "INVOICE")]
        Invoice,
        [EnumMember(Value = "PAYMENTS")]
        Payments,
        [EnumMember(Value = "FLATRATECASH")]
        FlatRateCash,
        [EnumMember(Value = "FLATRATEACCRUAL")]
        FlatRateAccrual,
    }
}