using System;
using System.Runtime.Serialization;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "")]
    public class SalesTrackingCategory
    {
        [DataMember(Name = "TrackingCategoryName", EmitDefaultValue = false)]
        public String Name { get; set; }

        [DataMember(Name = "TrackingOptionName", EmitDefaultValue = false)]
        public String Option { get; set; }
    }

    [DataContract(Namespace = "")]
    public class PurchasesTrackingCategory
    {
        [DataMember(Name = "TrackingCategoryName", EmitDefaultValue = false)]
        public String Name { get; set; }

        [DataMember(Name = "TrackingOptionName", EmitDefaultValue = false)]
        public String Option { get; set; }
    }
}
