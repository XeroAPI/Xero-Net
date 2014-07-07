using System.Runtime.Serialization;
using Xero.Api.Payroll.America.Model.Types;

namespace Xero.Api.Payroll.America.Model
{
    [DataContract(Namespace = "")]
    public class Account : Common.Model.Account
    {
        [DataMember]
        public AccountType Type { get; set; }
    }
}
