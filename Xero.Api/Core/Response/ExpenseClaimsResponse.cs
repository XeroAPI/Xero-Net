using System.Collections.Generic;
using Xero.Api.Common;
using Xero.Api.Core.Model;

namespace Xero.Api.Core.Response
{
    public class ExpenseClaimsResponse : XeroResponse<ExpenseClaim>
    {
        public IList<ExpenseClaim> ExpenseClaims { get; set; }

        public override IList<ExpenseClaim> Values
        {
            get { return ExpenseClaims; }
        }        
    }
}