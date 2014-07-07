using System.Collections.Generic;
using System.Runtime.Serialization;
using Xero.Api.Common;
using Xero.Api.Payroll.America.Model;

namespace Xero.Api.Payroll.America.Response
{
    [DataContract(Namespace = "", Name = "PayRuns")]
    public class PayRunsResponse : XeroResponse<PayRun>
    {
        public IList<PayRun> PayRuns { get; set; }

        public override IList<PayRun> Values
        {
            get { return PayRuns; }
        }
    }
}