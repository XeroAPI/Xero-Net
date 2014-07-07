using System;
using System.Linq;
using NUnit.Framework;
using Xero.Api.Payroll.Australia.Model.Status;
using Xero.Api.Payroll.Common.Model;

namespace PayrollTests.AU.Integration.TimeSheets
{
    [TestFixture]
    public class Create : TimesheetTest
    {
        [TestFixtureSetUp]
        public void CreateSetUp()
        {
            
        }
        [Test]
        public void create_timesheet()
        {
            var timesheet = Api.Create(new Timesheet
            {
                EmployeeId = the_employee_id(),
                StartDate = timesheet_start_date(),
                EndDate = timesheet_start_date().AddDays(6),
                Status = TimesheetStatus.Draft
            });
        }

    }
}
