using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Setup
{
    [DataContract(Namespace = "")]
    public class Accounts
    {
        [DataMember]
        public int Total { get; set; }

        [DataMember]
        public int New { get; set; }

        [DataMember]
        public int Updated { get; set; }

        [DataMember]
        public int Deleted { get; set; }

        [DataMember]
        public int Locked { get; set; }

        [DataMember]
        public int System { get; set; }

        [DataMember]
        public int Errored { get; set; }

        [DataMember]
        public int NewOrUpdated { get; set; }

        [DataMember]
        public bool Present { get; set; }
    }
}