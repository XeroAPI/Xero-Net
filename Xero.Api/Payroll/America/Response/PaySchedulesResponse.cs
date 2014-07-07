using System.Collections.Generic;
using Xero.Api.Common;
using Xero.Api.Payroll.America.Model;

namespace Xero.Api.Payroll.America.Response
{
    public class PaySchedulesResponse : XeroResponse<PaySchedule>
    {
        public IList<PaySchedule> PaySchedules { get; set; }

        public override IList<PaySchedule> Values
        {
            get { return PaySchedules; }
        }
    }
}