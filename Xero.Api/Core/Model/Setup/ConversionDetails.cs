using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Setup
{
    [DataContract(Namespace = "")]
    public class ConversionDetails
    {
        [DataMember]
        public string ConversionProductName;

        [DataMember]
        public string OriginatingProductName;

        [DataMember]
        public string OriginatingProductVersion;
    }
}