using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Xero.Api.Common;
using Xero.Api.Core.Model.Status;
using Xero.Api.Core.Model.Types;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "")]
    public class Invoice : HasUpdatedDate
    {
        [DataMember(Name = "InvoiceID", EmitDefaultValue = false)]
        public Guid Id { get; set; }

        [DataMember(Name = "InvoiceNumber", EmitDefaultValue = false)]
        public string Number { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Contact Contact { get; set; }

        [DataMember(Name = "Type")]
        public InvoiceType Type { get; set; }

        [DataMember]
        public InvoiceStatus Status { get; set; }

        [DataMember]
        public LineAmountType LineAmountTypes { get; set; }
        
        [DataMember(EmitDefaultValue = false)]
        public DateTime? Date { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public DateTime? DueDate { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public decimal? SubTotal { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public decimal? TotalTax { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public decimal? Total { get; set; }
        
        [DataMember(EmitDefaultValue = false)]
        public string CurrencyCode { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public DateTime? FullyPaidOnDate { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public decimal? AmountDue { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public decimal? AmountPaid { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public decimal? AmountCredited { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public bool? HasAttachments { get; set; }

        [DataMember(Name = "LineItems", EmitDefaultValue = false)]
        public List<LineItem> Items { get; set; }
    }
}
