using System.Collections.Generic;
using Xero.Api.Common;
using Xero.Api.Payroll.Australia.Model;

namespace Xero.Api.Payroll.Australia.Response
{
    public class TimesheetsResponse : XeroResponse<Timesheet>
    {
        public IList<Timesheet> Timesheets { get; set; }

        public override IList<Timesheet> Values
        {
            get { return Timesheets; }
        }
    }
}
