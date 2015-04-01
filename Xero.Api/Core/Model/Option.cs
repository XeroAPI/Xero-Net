using System;
using System.Runtime.Serialization;
using Xero.Api.Common;
using Xero.Api.Core.Model.Status;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "")]
    public class Option : CoreData, IHasId
    {
        [DataMember(Name = "TrackingOptionID", EmitDefaultValue = false)]
        public Guid Id { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public TrackingOptionStatus Status { get; set; }
    }
}