using System.Runtime.Serialization;
using Xero.Api.Common;

namespace Xero.Api.Payroll.Australia.Model
{
    [DataContract(Namespace = "")]
    public class SuperFundProduct : HasUpdatedDate
    {
        [DataMember(Name = "ABN")]
        // Australian Business Number
        public string Abn { get; set; }

        [DataMember(Name = "SPIN")]
        // Superannuation Product Identification Number 
        public string Spin { get; set; }

        [DataMember]
        public string ProductName { get; set; }
    }
}