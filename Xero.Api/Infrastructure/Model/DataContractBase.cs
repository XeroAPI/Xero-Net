using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Xero.Api.Infrastructure.Model
{
    [DataContract(Namespace = "")]
    public class DataContractBase
    {
        [DataMember(EmitDefaultValue = false)]
        public List<ValidationError> ValidationErrors { get; set; }


    }
}