using System;
using System.Runtime.Serialization;

namespace Xero.Api.Common
{
    [DataContract(Namespace = "")]
    public abstract class HasUpdatedDate
    {
        [DataMember(Name = "UpdatedDateUTC", EmitDefaultValue = false)]
        public DateTime? UpdatedDateUtc { get; set; }
    }
}
