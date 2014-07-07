using System.Collections.Generic;
using Xero.Api.Common;
using Xero.Api.Core.Model;

namespace Xero.Api.Core.Response
{
    public class InvoicesResponse : XeroResponse<Invoice>
    {
        public List<Invoice> Invoices { get; set; }

        public override IList<Invoice> Values
        {
            get { return Invoices; }
        }
    }
}