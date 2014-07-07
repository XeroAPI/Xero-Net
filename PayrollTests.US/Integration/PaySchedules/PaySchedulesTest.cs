using System;
using Xero.Api.Payroll.America.Model;
using Xero.Api.Payroll.America.Model.Types;

namespace PayrollTests.US.Integration.PaySchedules
{
    public abstract class PaySchedulesTest : ApiWrapperTest
    {
        public PaySchedule Given_a_payschedule()
        {
            return Api.Create(new PaySchedule
            {
                Name = "New Schedule",
                ScheduleType = ScheduleType.Weekly,
                StartDate = DateTime.Today,
                PaymentDate = DateTime.Today.AddDays(8)

            });
        }
    }
}
