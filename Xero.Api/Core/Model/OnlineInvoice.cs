using System.Runtime.Serialization;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "")]
    public class OnlineInvoice
    {
        [DataMember]
        public string OnlineInvoiceUrl { get; set; }
    }
}