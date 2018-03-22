using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Types
{
    [DataContract(Namespace = "")]
    public enum CreditNoteType
    {
        Unknown = 0,
        [EnumMember(Value = "ACCPAYCREDIT")]
        AccountsPayable = 1,
        [EnumMember(Value = "ACCRECCREDIT")]
        AccountsReceivable      
    }
}