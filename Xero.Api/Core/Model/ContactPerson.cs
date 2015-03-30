using System;
using System.Runtime.Serialization;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "")]
    public class ContactPerson : CoreData
    {
        [DataMember(Name = "ContactPersonID", EmitDefaultValue = false)]
        public Guid ContactPersonId { get; set; }
        
        [DataMember(EmitDefaultValue = false)]
        public string FirstName { get; set; }
        
        [DataMember(EmitDefaultValue = false)]
        public string LastName { get; set; }
        
        [DataMember(EmitDefaultValue = false)]
        public string EmailAddress { get; set; }
        
        [DataMember(EmitDefaultValue = false)]
        public bool? IncludeInEmails { get; set; }
    }
}