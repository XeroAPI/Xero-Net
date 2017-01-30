using System;
using System.Runtime.Serialization;
using Xero.Api.Payroll.Australia.Model.Types;

namespace Xero.Api.Payroll.Australia.Model
{
    [DataContract(Namespace = "")]
    public class EarningsLine
    {
        [DataMember(Name = "EarningsRateID")]
        public Guid EarningsRateId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public decimal? Amount { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public decimal? AnnualSalary { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public decimal? RatePerUnit { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public decimal? NormalNumberOfUnits { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public decimal? NumberOfUnitsPerWeek { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public decimal? NumberOfUnits { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public EarningsRateCalculationType CalculationType { get; set; }
    } 
}