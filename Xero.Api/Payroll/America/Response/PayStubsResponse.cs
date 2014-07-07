using System.Collections.Generic;
using Xero.Api.Common;
using Xero.Api.Payroll.America.Model;

namespace Xero.Api.Payroll.America.Response
{
    public class PayStubsResponse : XeroResponse<PayStub>
    {
        public override IList<PayStub> Values
        {
            get { return PayStubs; }
        }

        public IList<PayStub> PayStubs { get; set; }
    }
}