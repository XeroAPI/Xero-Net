using System.Collections.Generic;
using System.Runtime.Serialization;
using Xero.Api.Common;
using Xero.Api.Core.Model.Status;
using Xero.Api.Infrastructure.Model;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "")]
    public abstract class CoreData : HasUpdatedDate
    {
        [DataMember(EmitDefaultValue = false, Name = "ValidationErrors")]
        public List<ValidationError> Errors { get; set; }

        [DataMember(EmitDefaultValue = false, Name = "Warnings")]
        public List<Warning> Warnings { get; set; }

        // It is called StatusAttributeString in JSON but is an XML attribute in XML
        [DataMember(EmitDefaultValue = false, Name = "StatusAttributeString")]
        public ValidationStatus ValidationStatus { get; set; }
    }
}
