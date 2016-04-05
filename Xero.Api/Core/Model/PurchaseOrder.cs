using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Xero.Api.Common;
using Xero.Api.Core.Model.Status;
using Xero.Api.Core.Model.Types;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "")]
    public class PurchaseOrder : HasUpdatedDate, IHasId
    {
        [DataMember(Name = "PurchaseOrderID", EmitDefaultValue = false)]
        public Guid Id { get; set; }

        [DataMember(Name = "PurchaseOrderNumber", EmitDefaultValue = false)]
        public string Number { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public DateTime? Date { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public DateTime? DeliveryDate { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public DateTime? ExpectedArrivalDate { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string DeliveryAddress { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string AttentionTo { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Telephone { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string DeliveryInstructions { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public decimal? TotalDiscount { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public bool SentToContact { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Reference { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string CurrencyCode { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public decimal? CurrencyRate { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Contact Contact { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Guid? BrandingThemeID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public PurchaseOrderStatus? Status { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public LineAmountType LineAmountTypes { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<LineItem> LineItems { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public decimal? SubTotal { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public decimal? TotalTax { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public decimal? Total { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public bool? HasAttachments { get; set; }
    }
}
