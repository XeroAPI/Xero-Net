using System.Collections.Generic;
using Xero.Api.Common;
using Xero.Api.Core.Model;

namespace Xero.Api.Core.Response
{
    public class BankTransfersResponse : XeroResponse<BankTransfer>
    {
        public IList<BankTransfer> BankTransfers { get; set; }

        public override IList<BankTransfer> Values
        {
            get { return BankTransfers; }
        }
    }
}