using System.Collections.Generic;
using Xero.Api.Common;
using Xero.Api.Core.Model;

namespace Xero.Api.Core.Response
{
    public class ReceiptsResponse : XeroResponse<Receipt>
    {
        public IList<Receipt> Receipts { get; set; }

        public override IList<Receipt> Values
        {
            get { return Receipts; }
        }        
    }
}