using System.Runtime.Serialization;
using Xero.Api.Core.Model.Types;

namespace Xero.Api.Payroll.Australia.Model
{
    [DataContract(Namespace = "")]
    public class Account : Common.Model.Account
    {
        [DataMember]
        public AccountType Type { get; set; }        
    }
}
