using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Types
{
    [DataContract(Namespace = "")]
    public enum CreditNoteType
    {
        [EnumMember(Value = "ACCPAYCREDIT")]
        AccountsPayable,
        [EnumMember(Value = "ACCRECCREDIT")]
        AccountsReceivable        
    }
}