using System;
using System.Runtime.Serialization;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "")]
    public class DefaultTrackingCategory
    {
        [DataMember(Name = "TrackingCategoryName", EmitDefaultValue = false)]
        public String Name { get; set; }

        [DataMember(Name = "TrackingOptionName", EmitDefaultValue = false)]
        public String Option { get; set; }
    }
}
