using System;
using System.Runtime.Serialization;
using Xero.Api.Common;
using Xero.Api.Payroll.Australia.Model.Types;

namespace Xero.Api.Payroll.Australia.Model
{
    [DataContract(Namespace = "")]
    public class PayrollCalendar : HasUpdatedDate
    {
        [DataMember(Name = "PayrollCalendarID", EmitDefaultValue = false)]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public CalendarType CalendarType { get; set; }

        [DataMember]
        public DateTime? PaymentDate { get; set; }

        [DataMember]
        public DateTime? StartDate { get; set; }
    }
}
