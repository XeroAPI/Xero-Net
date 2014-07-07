using System.Collections.Generic;
using Xero.Api.Common;
using Xero.Api.Payroll.Australia.Model;

namespace Xero.Api.Payroll.Australia.Response
{
    public class SuperFundProductsResponse : XeroResponse<SuperFundProduct>
    {
        public IList<SuperFundProduct> SuperFundProducts { get; set; }

        public override IList<SuperFundProduct> Values
        {
            get { return SuperFundProducts; }
        }
    }
}