using System.Collections.Generic;
using Xero.Api.Common;
using Xero.Api.Core.Model;

namespace Xero.Api.Core.Response
{
    public class ItemsResponse : XeroResponse<Item>
    {
        public IList<Item> Items { get; set; }

        public override IList<Item> Values
        {
            get { return Items; }
        }
    }
}
