using System;
using NUnit.Framework;
using Xero.Api.Payroll.Australia.Model;
using Xero.Api.Payroll.Australia.Model.Types;

namespace PayrollTests.AU.Integration.PayrollCalendars
{
    [TestFixture]
    public class Create : ApiWrapperTest
    {
        [Test]
        public void create_payroll_calendar()
        {
            var pc = Api.Create(new PayrollCalendar
            {
                Name = "New Calendar",
                CalendarType = CalendarType.Weekly,
                StartDate = DateTime.Today,
                PaymentDate = DateTime.Today.AddDays(14)
            });

            Assert.IsTrue(pc.Id != Guid.Empty);
        }
    }
}
