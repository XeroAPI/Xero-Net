using System.Collections.Generic;
using Xero.Api.Common;
using Xero.Api.Core.Model;

namespace Xero.Api.Core.Response
{
    public class BankTransactionsResponse : XeroResponse<BankTransaction>
    {
        public IList<BankTransaction> BankTransactions { get; set; }

        public override IList<BankTransaction> Values
        {
            get { return BankTransactions; }
        }
    }
}