using System.Collections.Generic;
using Xero.Api.Common;
using Xero.Api.Core.Model;

namespace Xero.Api.Core.Response
{
    public class TaxRatesResponse : XeroResponse<TaxRate>
    {
        public IList<TaxRate> TaxRates { get; set; }

        public override IList<TaxRate> Values
        {
            get { return TaxRates; }
        }
    }
}