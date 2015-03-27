using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Xero.Api.Common;
using Xero.Api.Core.Model.Status;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "")]
    public class TrackingCategory : CoreData, IHasId
    {
        [DataMember(Name = "TrackingCategoryID")]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public TrackingCategoryStatus Status { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<Option> Options { get; set; }
    }
}