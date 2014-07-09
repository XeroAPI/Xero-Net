using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Setup
{
    [DataContract(Namespace = "")]
    public class ImportSummary
    {
        [DataMember]
        public Accounts Accounts { get; set; }

        [DataMember]
        public Organisation Organisation { get; set; }

        [DataMember]
        public Contacts Contacts { get; set; }
    }
}