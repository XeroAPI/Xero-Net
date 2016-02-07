using System.Collections.Generic;
using System.Runtime.Serialization;
using Xero.Api.Common;

namespace Xero.Api.Core.Model.Setup
{
    [DataContract(Namespace = "")]
    public class Setup : CoreData
    {
        [DataMember]
        public ConversionDetails ConversionDetails { get; set; }

        [DataMember]
        public ConversionDate ConversionDate { get; set; }

        [DataMember]
        public List<Account> Accounts { get; set; }

        [DataMember]
        public List<ConversionBalance> ConversionBalances { get; set; }
    }
}
