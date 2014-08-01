using System.Runtime.Serialization;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "")]
    public class LineItem
    {
        [DataMember(EmitDefaultValue = false)]
        public string Description { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public decimal? Quantity { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public decimal? UnitAmount { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string AccountCode { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string ItemCode { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string TaxType { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public decimal? TaxAmount { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public decimal? LineAmount { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public decimal? DiscountRate { get; set; }

        [DataMember(EmitDefaultValue = false, Name = "Tracking")]
        public ItemTracking Tracking { get; set; }
    }
}
