using System;
using System.Runtime.Serialization;
using Xero.Api.Common;
using Xero.Api.Core.Model.Types;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "")]
    public class User : HasUpdatedDate, IHasId
    {
        [DataMember(Name = "UserID", EmitDefaultValue = false)]
        public Guid Id { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string EmailAddress { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string FirstName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string LastName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public DateTime? UpdatedDate { get; set; }

        [DataMember]
        public bool? IsSubscriber { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public UserRole OrganisationRole { get; set; }
    }
}
