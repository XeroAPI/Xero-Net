using System.Runtime.Serialization;
using Xero.Api.Common;
using Xero.Api.Core.Model.Types;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "")]
    public class ExternalLink : CoreData
    {
        [DataMember]
        public ExternalLinkType LinkType { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Url { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Description { get; set; }
    }
}