using System.Collections.Generic;
using Xero.Api.Common;
using Xero.Api.Payroll.Australia.Model;

namespace Xero.Api.Payroll.Australia.Response
{
    public class PayRunsResponse : XeroResponse<PayRun>
    {
        public IList<PayRun> PayRuns { get; set; }

        public override IList<PayRun> Values
        {
            get { return PayRuns; }
        }
    }
}