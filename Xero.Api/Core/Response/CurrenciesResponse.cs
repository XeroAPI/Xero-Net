using System.Collections.Generic;
using Xero.Api.Common;
using Xero.Api.Core.Model;

namespace Xero.Api.Core.Response
{
    public class CurrenciesResponse : XeroResponse<Currency>
    {
        public List<Currency> Currencies { get; set; }

        public override IList<Currency> Values
        {
            get { return Currencies; }
        }
    }
}

