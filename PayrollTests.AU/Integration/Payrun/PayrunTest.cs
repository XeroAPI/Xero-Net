using System;
using System.Linq;
using Xero.Api.Payroll.Australia.Model;
using Xero.Api.Payroll.Australia.Model.Types;

namespace PayrollTests.AU.Integration.Payrun
{
    public abstract class PayrunTest : ApiWrapperTest
    {

        public PayRun Given_a_payrun()
        {
            var payrun = Api.Create(new PayRun
            {
                PayrollCalendarId = the_payroll_calendar_id(),
            });

            return payrun;
        }



        public Guid the_payroll_calendar_id()
        {
            var pc = Api.PayrollCalendars.Find();
            if (pc.FirstOrDefault().Id != Guid.Empty)
            {
                return pc.FirstOrDefault().Id;
            }
            else
            {
                return Api.Create(new PayrollCalendar
                {
                    Name = "New Calendar",
                    CalendarType = CalendarType.Weekly,
                    StartDate = DateTime.Today,
                    PaymentDate = DateTime.Today.AddDays(7)
                }).Id;
            }
        }

    }
}
