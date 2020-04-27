using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Xero.Api.Common;
using Xero.Api.Core.Model.Status;
using Xero.Api.Core.Model.Types;
using Xero.Api.Infrastructure.ThirdParty.ServiceStack.Text.Common;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "")]
    public class BatchPayment : HasUpdatedDate, IHasId
    {
        [DataMember(Name = "BatchPaymentID", EmitDefaultValue = false)]
        public Guid Id { get; set; }

        [DataMember(Name = "Type", EmitDefaultValue = false)]
        public BatchPaymentType? Type { get; set; }

        [DataMember(Name = "Status", EmitDefaultValue = false)]
        public BatchPaymentStatus? Status { get; set; }

        [DataMember(Name = "Account")]
        public Account Account { get; set; }

        [DataMember(Name = "Particulars", EmitDefaultValue = false)]
        public string Particulars { get; set; }

        [DataMember(Name = "Code", EmitDefaultValue = false)]
        public string Code { get; set; }

        [DataMember(Name = "Reference", EmitDefaultValue = false)]
        public string Reference { get; set; }

        [DataMember(Name = "Details", EmitDefaultValue = false)]
        public string Details { get; set; }

        [DataMember(Name = "Narrative", EmitDefaultValue = false)]
        public string Narrative { get; set; }

		public DateTime? Date { get; set; }

		[DataMember(Name = "Date", EmitDefaultValue = false)]
		public string DateString {
			get
			{
				return Date.Value.ToString("yyyy-MM-dd");
			}
			set
			{
				Date = DateTimeSerializer.ParseDateTimeOffset(value).UtcDateTime;
			}
		}

		[DataMember(Name = "Payments")]
        public List<BatchPaymentPayment> Payments { get; set; }

        [DataMember(Name = "TotalAmount", EmitDefaultValue = false)]
        public decimal? Total { get; set; }

        [DataMember(Name = "IsReconciled", EmitDefaultValue = false)]
        public bool? IsReconciled { get; set; }
    }
}