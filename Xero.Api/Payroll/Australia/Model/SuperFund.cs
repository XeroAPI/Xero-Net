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
        public long Abn { get; set; }

        [DataMember(Name = "SPIN")]
        // Superannuation Product Identification Number 
        public string Spin { get; }
        
        [DataMember(Name = "USI")]
        //Unique superannuation identifier
        public string Spin { get; set; }
        
        [DataMember]
        public SuperfundType Type { get; set; }

        [DataMember]
        public string AccountName { get; set; }

        [DataMember]
        public long AccountNumber { get; set; }
        
        [DataMember(Name ="BSB")]
        public int BankStateBranch { get; set; }

        [DataMember]
        public long EmployerNumber { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
