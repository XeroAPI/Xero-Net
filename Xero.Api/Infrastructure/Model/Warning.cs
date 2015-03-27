using System.Runtime.Serialization;

namespace Xero.Api.Infrastructure.Model
{
    [DataContract(Namespace = "")]
    public class Warning
    {
        [DataMember(EmitDefaultValue = false)]
        public string Message;
    }
}