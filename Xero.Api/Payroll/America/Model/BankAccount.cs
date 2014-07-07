using System.Runtime.Serialization;
using Xero.Api.Payroll.America.Model.Types;

namespace Xero.Api.Payroll.America.Model
{
    [DataContract(Namespace = "")]
    public class BankAccount
    {
        [DataMember]
        public string AccountHolderName { get; set; }

        [DataMember]
        public string StatementText { get; set; }

        [DataMember]
        public AccountType AccountType { get; set; }

        [DataMember]
        public int RoutingNumber { get; set; }

        [DataMember]
        public int AccountNumber { get; set; }

        [DataMember]
        public decimal? Amount { get; set; }

        [DataMember]
        public bool Remainder { get; set; }
    }
}