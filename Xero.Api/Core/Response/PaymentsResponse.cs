using System.Collections.Generic;
using Xero.Api.Common;
using Xero.Api.Core.Model;

namespace Xero.Api.Core.Response
{
    public class PaymentsResponse : XeroResponse<Payment>
    {
        public IList<Payment> Payments { get; set; }

        public override IList<Payment> Values
        {
            get { return Payments; }
        }
    }
}