using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Types
{
    [DataContract]
    public enum SalesTaxBasisType
    {
        [EnumMember(Value = "NONE")]
        None = 1,
        [EnumMember(Value = "ACCRUALS")]
        Accruals = 2,
        [EnumMember(Value = "ACCRUAL")]
        Accrual = 2,
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