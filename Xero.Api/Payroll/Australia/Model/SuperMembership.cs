using System;
using System.Runtime.Serialization;

namespace Xero.Api.Payroll.Australia.Model
{
    [DataContract(Namespace = "")]
    public class SuperMembership
    {
        [DataMember(Name = "SuperMembershipID", EmitDefaultValue = false)]
        public Guid Id { get; set; }

        [DataMember(Name = "SuperFundID")]
        public Guid SuperFundId { get; set; }

        [DataMember]
        public int EmployeeNumber { get; set; }
    }
}