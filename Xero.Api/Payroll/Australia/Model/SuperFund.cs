using System;
using System.Runtime.Serialization;
using Xero.Api.Common;
using Xero.Api.Payroll.Australia.Model.Types;

namespace Xero.Api.Payroll.Australia.Model
{
    [DataContract(Namespace = "")]
    public class SuperFund : HasUpdatedDate
    {
        [DataMember(Name = "SuperFundID", EmitDefaultValue = false)]
        public Guid Id { get; set; }
        
        [DataMember(Name = "ABN")]
        // Australian Business Number
        public string Abn { get; set; }

        [DataMember(Name = "SPIN")]
        // Superannuation Product Identification Number 
        public string Spin { get; private set; }
        
        [DataMember(Name = "USI")]
        //Unique superannuation identifier
        public string Usi { get; set; }
        
        [DataMember]
        public SuperfundType Type { get; set; }

        [DataMember]
        public string AccountName { get; set; }

        [DataMember]
        public string AccountNumber { get; set; }
        
        [DataMember(Name ="BSB")]
        public string BankStateBranch { get; set; }

        [DataMember]
        public string EmployerNumber { get; set; }
        
        [DataMember]
        public string  ElectronicServiceAddress { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
