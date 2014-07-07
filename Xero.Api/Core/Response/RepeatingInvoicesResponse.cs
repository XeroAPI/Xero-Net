using System.Collections.Generic;
using Xero.Api.Common;
using Xero.Api.Core.Model;

namespace Xero.Api.Core.Response
{
    public class RepeatingInvoicesResponse : XeroResponse<RepeatingInvoice>
    {
        public IList<RepeatingInvoice> RepeatingInvoices { get; set; }

        public override IList<RepeatingInvoice> Values
        {
            get { return RepeatingInvoices; }
        }
    }
}