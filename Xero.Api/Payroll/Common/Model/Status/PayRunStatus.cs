using System.Runtime.Serialization;

namespace Xero.Api.Payroll.Common.Model.Status
{
    [DataContract(Namespace = "")]
    public enum PayRunStatus
    {
        [EnumMember(Value= "DRAFT")]
        Draft,
        [EnumMember(Value = "POSTED")]
        Posted,
        [EnumMember(Value = "APPROVED")]
        Approved
    }
}