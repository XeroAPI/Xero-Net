using System;
using System.Runtime.Serialization;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "")]
    public sealed class Item
    {
        [DataMember(Name = "ItemID", EmitDefaultValue = false)]
        public Guid Id { get; set; }

        [DataMember]
        public string Code { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Description { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public PurchaseDetails PurchaseDetails { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public SalesDetails SalesDetails { get; set; }
    }
}
