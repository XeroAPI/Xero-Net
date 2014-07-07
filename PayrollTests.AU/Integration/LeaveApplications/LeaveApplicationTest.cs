using System;
using System.Linq;
using Xero.Api.Payroll.Australia.Model;

namespace PayrollTests.AU.Integration.LeaveApplications
{
    public abstract class LeaveApplicationTest :ApiWrapperTest
    {

        public LeaveApplication Given_a_leave_application()
        {
            var la = Api.Create(new LeaveApplication
            {
                EmployeeId = Given_an_employee().Id,
                LeaveTypeId = the_leavetype_id(),
                Title = "Annual",
                StartDate = DateTime.Today.AddDays(2),
                EndDate = DateTime.Today.AddDays(4),
            });

            return la;
        }



        public Employee Given_an_employee()
        {
            var employee = Api.Create(new Employee
            {
                FirstName = "Keith " + Guid.NewGuid().ToString("N"),
                LastName = "Morgan",
                PayrollCalendarID = employee_payroll_calendar_id(),
                OrdinaryEarningsRateID = earning_rates_id()
            });

            return employee;
        }



        public Guid the_leavetype_id()
        {
            return Api.PayItems.Find().FirstOrDefault().LeaveTypes.FirstOrDefault().Id;
        }



        public Guid employee_payroll_calendar_id()
        {
            var payruns = Api.PayRuns.Where("PayRunStatus == \"DRAFT\"").Find();
            if (payruns.FirstOrDefault().Id != Guid.Empty)
            {
                return payruns.FirstOrDefault().PayrollCalendarId;
            }
            else
            {
                var payroll_calendar_id = Api.PayrollCalendars.Find().First().Id;
                Api.Create(new PayRun
                {
                    PayrollCalendarId = payroll_calendar_id
                });
                return payroll_calendar_id;
            }
        }



        public Guid earning_rates_id()
        {
            var er = Api.PayItems.Find();
            return er.FirstOrDefault().EarningsRates.FirstOrDefault().Id;
        }

    }
}
