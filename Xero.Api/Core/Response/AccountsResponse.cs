using System.Collections.Generic;
using Xero.Api.Common;
using Xero.Api.Core.Model;

namespace Xero.Api.Core.Response
{
    public class AccountsResponse : XeroResponse<Account>
    {
        public List<Account> Accounts { get; set; }

        public override IList<Account> Values
        {
            get { return Accounts; }
        }
    }
}