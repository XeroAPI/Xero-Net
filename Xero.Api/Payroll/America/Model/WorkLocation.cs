using System;
using System.Runtime.Serialization;

namespace Xero.Api.Payroll.America.Model
{
    [DataContract(Namespace = "")]
    public class WorkLocation : Address
    {
        [DataMember(Name = "WorkLocationID")]
        public Guid Id { get; set; }

        [DataMember]
        public bool IsPrimary { get; set; }
    }
}
