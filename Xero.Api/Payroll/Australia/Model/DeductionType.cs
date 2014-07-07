using System;
using System.Runtime.Serialization;
using Xero.Api.Common;

namespace Xero.Api.Payroll.Australia.Model
{
    [DataContract(Namespace = "")]
    public class DeductionType : HasUpdatedDate
    {
        [DataMember(Name = "DeductionTypeID", EmitDefaultValue = false)]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string AccountCode { get; set; }

        [DataMember]
        public bool ReducesTax { get; set; }

        [DataMember]
        public bool ReducesSuper { get; set; }        
    }
}
