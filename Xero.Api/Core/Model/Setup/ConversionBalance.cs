using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Setup
{
    [DataContract(Namespace = "")]
    public class ConversionBalance
    {
        [DataMember(EmitDefaultValue = false)]
        public decimal? Balance { get; set; }

        [DataMember]
        public string AccountCode { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<BalanceDetail> BalanceDetails { get; set; }
    }

    [DataContract(Namespace = "")]
    public class BalanceDetail
    {
        [DataMember]
        public decimal Balance { get; set; }

        [DataMember]
        public string CurrencyCode { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public decimal? CurrencyRate { get; set; }
    }
}