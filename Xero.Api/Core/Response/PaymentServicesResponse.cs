using System.Collections.Generic;
using Xero.Api.Common;
using Xero.Api.Core.Model;

namespace Xero.Api.Core.Response
{
    public class PaymentServicesResponse : XeroResponse<PaymentService>
    {
        public List<PaymentService> PaymentServices { get; set; }

        public override IList<PaymentService> Values
        {
            get { return PaymentServices; }
        }
    }
}