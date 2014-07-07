using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Types
{
    [DataContract(Namespace = "")]
    public enum UnitType
    {
        [EnumMember(Value = "WEEKLY")]
        Weekly,
        [EnumMember(Value = "MONTHLY")]
        Monthly
    }
}