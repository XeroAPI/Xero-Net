using System;
using System.Runtime.Serialization;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "", Name = "TrackingCategory")]
    public class ItemTrackingCategory
    {
        [DataMember(Name = "TrackingCategoryID")]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Option { get; set; }
    }
}