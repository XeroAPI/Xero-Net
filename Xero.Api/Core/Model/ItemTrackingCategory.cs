using System;
using System.Runtime.Serialization;
using Xero.Api.Common;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "", Name = "TrackingCategory")]
    public class ItemTrackingCategory : CoreData, IHasId
    {
        [DataMember(Name = "TrackingCategoryID")]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Option { get; set; }
    }
}