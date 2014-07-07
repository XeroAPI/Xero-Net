using System.Runtime.Serialization;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "")]
    public class Balances
    {
        [DataMember(EmitDefaultValue = false)]
        public Balance AccountsReceivable { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Balance AccountsPayable { get; set; }
    }
}