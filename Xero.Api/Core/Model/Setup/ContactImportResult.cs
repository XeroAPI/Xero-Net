using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Setup
{
    [DataContract(Namespace = "")]
    public class Contacts
    {
        [DataMember]
        public int New { get; set; }

        [DataMember]
        public int Updated { get; set; }
    }
}