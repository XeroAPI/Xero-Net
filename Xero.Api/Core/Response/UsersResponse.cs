using System.Collections.Generic;
using Xero.Api.Common;
using Xero.Api.Core.Model;

namespace Xero.Api.Core.Response
{
    public class UsersResponse : XeroResponse<User>
    {
        public List<User> Users { get; set; }

        public override IList<User> Values
        {
            get { return Users; }
        }
    }
}