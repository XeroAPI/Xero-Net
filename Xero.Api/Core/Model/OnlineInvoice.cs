using System;
using System.Runtime.Serialization;

namespace Xero.Api.Core.Model
{
	[Serializable]
	[DataContract(Namespace = "")]
    public class OnlineInvoice
    {
        [DataMember]
        public string OnlineInvoiceUrl { get; set; }
    }
}