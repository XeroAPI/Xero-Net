using System.Runtime.Serialization;
using Xero.Api.Common;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "")]
    public class Balances : CoreData
    {
        [DataMember(EmitDefaultValue = false)]
        public Balance AccountsReceivable { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Balance AccountsPayable { get; set; }
    }
}