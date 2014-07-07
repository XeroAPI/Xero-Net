using System;
using NUnit.Framework;
using Xero.Api.Payroll.America.Model;

namespace PayrollTests.US.Integration.Employees
{
    [TestFixture]
    public class Update : EmployeesTest
    {
        [Test]
        public void update_employee_with_super_memberhsip()
        {
            var emp = Given_an_employee();

            var updated_emp = Api.Update(new Employee
            {
                Id = emp.Id,
            });
            Assert.IsTrue(updated_emp.Id != Guid.Empty);
        }

    }
}
