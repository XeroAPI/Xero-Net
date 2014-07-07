using System;
using System.Runtime.Serialization;

namespace Xero.Api.Payroll.Common.Model
{
    [DataContract(Namespace = "")]
    public abstract class Account
    {
        [DataMember(Name = "AccountID", EmitDefaultValue = false)]
        public Guid Id { get; set; }

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}