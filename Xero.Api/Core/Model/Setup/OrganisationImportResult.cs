using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Setup
{
    [DataContract(Namespace = "")]
    public class Organisation
    {
        public bool Present { get; set; }
    }
}