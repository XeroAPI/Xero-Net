using System.Runtime.Serialization;
using Xero.Api.Common;
using Xero.Api.Core.Model.Setup;

namespace Xero.Api.Core.Response
{
    [DataContract(Namespace = "")]
    public class SetupResponse : XeroResponse
    {
        [DataMember]
        public ImportSummary ImportSummary { get; private set; }
    }
}
