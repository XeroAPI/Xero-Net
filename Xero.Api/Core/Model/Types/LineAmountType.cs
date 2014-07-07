using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Types
{
    [DataContract(Namespace = "")]
    public enum LineAmountType
    {
        [EnumMember]
        Exclusive,
        [EnumMember]
        Inclusive,
        [EnumMember]
        NoTax        
    }
}