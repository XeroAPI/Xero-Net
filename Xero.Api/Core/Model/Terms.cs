using System.Runtime.Serialization;
using Xero.Api.Common;
using Xero.Api.Core.Model.Types;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "")]
    public class Terms : CoreData
    {
        [DataMember]
        public int Day { get; set; }

        [DataMember(Name = "Type")]
        public PaymentTermType TermType { get; set; }
    }
}