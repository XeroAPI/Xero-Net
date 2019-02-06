using System;
using System.Runtime.Serialization;

namespace Xero.Api.Infrastructure.Model
{
	[Serializable]
	[DataContract(Namespace = "")]
    public class ValidationError
    {
        [DataMember(EmitDefaultValue = false)]
        public string Message { get; set; }
    }
}