using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Types
{
    [DataContract(Namespace = "")]
    public enum UserRole
    {
        [EnumMember(Value = "UNKNOWN")]
        Unknown = -1,
        [EnumMember(Value = "READONLY")]
        ReadOnly = 1,
        [EnumMember(Value = "INVOICEONLY")]
        InvoiceOnly = 2,
        [EnumMember(Value = "STANDARD")]
        Standard = 3,
        [EnumMember(Value = "FINANCIALADVISER")]
        FinancialAdviser = 4,
        [EnumMember(Value = "MANAGEDCLIENT")]
        ManagedClient = 5,
        [EnumMember(Value = "CASHBOOKCLIENT")]
        CashBookClient = 6
    }
}