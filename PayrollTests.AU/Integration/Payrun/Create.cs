using System;
using NUnit.Framework;
using Xero.Api.Payroll.Australia.Model;
using Xero.Api.Payroll.Australia.Model.Types;
using Xero.Api.Payroll.Common.Model.Status;

namespace PayrollTests.AU.Integration.Payrun
{
    [TestFixture]
    public class Create : PayrunTest
    {
        [Test]
        public void create_scheduled_payrun()
        {
            var payrun = Api.Create(new PayRun
            {
                PayrollCalendarId = the_payroll_calendar_id()
            });
            Assert.True(payrun.Id != Guid.Empty);
        }



        [Test]
        public void create_unscheduled_payrun()
        {
            var payrun = Api.Create(new PayRun
            {
                PayrollCalendarId = the_payroll_calendar_id(),
                PayRunPeriodEndDate = DateTime.Today.AddDays(12)
            });
            Assert.True(payrun.Id != Guid.Empty);
        }



        [Test]
        public void post_payrun()
        {
            var payroll_calendar_id=Api.Create(new PayrollCalendar
            {
                Name = "Weekly Calendar",
                CalendarType = CalendarType.Weekly,
                StartDate = DateTime.Today,
                PaymentDate = DateTime.Today.AddDays(7)
            }).Id;

            var payrun = Api.Create(new PayRun
            {
                PayrollCalendarId = payroll_calendar_id,
                PayRunPeriodEndDate = DateTime.Today.AddDays(13),
                PayRunStatus = PayRunStatus.Posted
            });
            Assert.True(payrun.Id != Guid.Empty);
        }

    }
}
