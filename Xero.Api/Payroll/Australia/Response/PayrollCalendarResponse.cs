using System.Collections.Generic;
using Xero.Api.Common;
using Xero.Api.Payroll.Australia.Model;

namespace Xero.Api.Payroll.Australia.Response
{
    public class PayrollCalendarResponse : XeroResponse<PayrollCalendar>
    {
        public IList<PayrollCalendar> PayrollCalendars { get; set; }

        public override IList<PayrollCalendar> Values
        {
            get { return PayrollCalendars; }
        }
    }
}