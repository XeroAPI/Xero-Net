using System.Runtime.Serialization;
using Xero.Api.Common;
using Xero.Api.Core.Model.Types;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "")]
    public class Phone : CoreData
    {
        public Phone()
        {
            PhoneType = PhoneType.Default;
        }

        [DataMember]
        public PhoneType PhoneType { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string PhoneNumber { get; set; }
        
        [DataMember(EmitDefaultValue = false)]
        public string PhoneAreaCode { get; set; }
        
        [DataMember(EmitDefaultValue = false)]
        public string PhoneCountryCode { get; set; }        
    }
}
