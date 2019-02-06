using System;
using System.Runtime.Serialization;

namespace Xero.Api.Infrastructure.Model
{
	[Serializable]
	[DataContract(Namespace = "")]
    public class Warning
    {
        [DataMember(EmitDefaultValue = false)]
        public string Message { get; set; }
    }
}