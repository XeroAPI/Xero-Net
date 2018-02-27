using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Types
{
    [DataContract(Namespace = "")]
    public enum SystemAccountType
    {
        [EnumMember(Value = "DEBTORS")]
        Debtors = 1,
        [EnumMember(Value = "CREDITORS")]
        Creditors = 2,
        [EnumMember(Value = "BANKCURRENCYGAIN")]
        BankCurrencyGain = 3,
        [EnumMember(Value = "GST")]
        GST = 4,
        [EnumMember(Value = "GSTONIMPORTS")]
        GSTOnImports = 5,
        [EnumMember(Value = "HISTORICAL")]
        Historical = 6,
        [EnumMember(Value = "REALISEDCURRENCYGAIN")]
        RealisedCurrencyGain = 7,
        [EnumMember(Value = "RETAINEDEARNINGS")]
        RetainedEarnings = 8,
        [EnumMember(Value = "ROUNDING")]
        Rounding = 9,
        [EnumMember(Value = "TRACKINGTRANSFERS")]
        TrackingTransfers = 10,
        [EnumMember(Value = "UNPAIDEXPCLM")]
        UnpaidExpenseClaim = 11,
        [EnumMember(Value = "UNREALISEDCURRENCYGAIN")]
        UnrealisedCurrencyGain = 12,
        [EnumMember(Value = "WAGEPAYABLES")]
        WagePayables = 13,
        [EnumMember(Value = "CISLIABILITY")]
        CisLiability = 14,
        [EnumMember(Value = "CISLABOUR")]
        CisLabour = 15,
        [EnumMember(Value = "CISMATERIALS")]
        CisMaterials = 16
    } 
}
