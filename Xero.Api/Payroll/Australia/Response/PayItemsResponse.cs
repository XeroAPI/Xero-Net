using System.Collections.Generic;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Payroll.Australia.Model;

namespace Xero.Api.Payroll.Australia.Response
{
    public class PayItemsResponse : IXeroResponse<PayItems>
    {
        public PayItems PayItems { get; private set; }
        
        public IList<PayItems> Values { get { return new[] { PayItems }; } }
    }
}