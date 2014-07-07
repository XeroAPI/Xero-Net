using System;
using System.Runtime.Serialization;
using Xero.Api.Common;

namespace Xero.Api.Payroll.Australia.Model
{
    [DataContract(Namespace = "")]
    public class ReimbursementType : HasUpdatedDate
    {
        [DataMember(Name = "ReimbursementTypeID", EmitDefaultValue = false)]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string AccountCode { get; set; }        
    }
}