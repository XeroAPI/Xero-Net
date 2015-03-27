using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Xero.Api.Common;
using Xero.Api.Core.Model.Status;
using Xero.Api.Core.Model.Types;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "")]
    public class RepeatingInvoice : CoreData, IHasId
    {
        [DataMember(Name = "RepeatingInvoiceID", EmitDefaultValue = false)]
        public Guid Id { set; get; }

        [DataMember(EmitDefaultValue = false)]
        public InvoiceType Type { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Contact Contact { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Schedule Schedule { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<LineItem> LineItems { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public LineAmountType LineAmountTypes { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Reference { get; set; }

        [DataMember(Name = "BrandingThemeID", EmitDefaultValue = false)]
        public Guid BrandingThemeId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string CurrencyCode { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public InvoiceStatus Status { get; set; }

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
