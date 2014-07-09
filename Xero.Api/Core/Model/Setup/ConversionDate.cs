using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Setup
{
    [DataContract(Namespace = "")]
    public class ConversionDate
    {
        [DataMember]
        public int? Month { get; set; }

        [DataMember]
        public int? Year { get; set; }
    }
}