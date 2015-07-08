using System.Runtime.Serialization;
using Xero.Api.Common;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "")]
    public class Currency : CoreData
    {
        [DataMember(EmitDefaultValue = false)]
        public string Code { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Description { get; set; }
    }
}
