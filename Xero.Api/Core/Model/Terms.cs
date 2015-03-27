using System.Runtime.Serialization;
using Xero.Api.Core.Model.Types;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "")]
    public class Terms : CoreData
    {
        [DataMember(EmitDefaultValue = false)]
        public int Day { get; set; }

        [DataMember]
        public PaymentTermType TermType { get; set; }
    }
}