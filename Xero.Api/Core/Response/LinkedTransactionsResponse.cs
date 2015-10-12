using System.Collections.Generic;
using Xero.Api.Common;
using Xero.Api.Core.Model;

namespace Xero.Api.Core.Response
{
    public class LinkedTransactionsResponse : XeroResponse<LinkedTransaction>
    {
        public List<LinkedTransaction> LinkedTransactions { get; set; }

        public override IList<LinkedTransaction> Values
        {
            get { return LinkedTransactions; }
        }
    }
}