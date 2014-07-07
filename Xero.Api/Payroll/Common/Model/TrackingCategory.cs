using System;
using System.Runtime.Serialization;

namespace Xero.Api.Payroll.Common.Model
{
    [DataContract(Namespace = "")]
    public class TrackingCategory
    {
        [DataMember(Name = "TrackingCategoryID")]
        public Guid Id { get; set; }

        [DataMember(Name = "TrackingCategoryName")]
        public string Name { get; set; }
    }
}
