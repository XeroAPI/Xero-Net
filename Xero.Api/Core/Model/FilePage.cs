using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "")]
    public class FilePage
    {
        [DataMember(EmitDefaultValue = false)]
        public List<File> Items { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public long TotalCount { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public long Page { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public long PerPage { get; set; }
    }
}