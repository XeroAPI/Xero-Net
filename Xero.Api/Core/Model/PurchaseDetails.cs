using System.Runtime.Serialization;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "")]
    public sealed class PurchaseDetails : ItemDetails
    {
        [DataMember]
        public string COGSAccountCode { get; set; }
    }
}