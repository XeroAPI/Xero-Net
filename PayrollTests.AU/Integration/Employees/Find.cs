using System.Linq;
using NUnit.Framework;

namespace PayrollTests.AU.Integration.Employees
{
    [TestFixture]
    public class Find : EmployeesTest
    {
        [Test]
        public void find_all_employees()
        {
            var emp = Api.Employees.Find();
            Assert.Greater(emp.Count(), 0);
        }

        [Test]
        public void find_by_id()
        {
            var expected = Given_an_employee().Id;
            var employee = Api.Employees.Find(expected);

            Assert.AreEqual(expected, employee.Id);
        }

        [Test]
        public void find_by_status()
        {
            var terminated = given_terminated_employee();

            Assert.True(Api.Employees
                .Where("Status == \"TERMINATED\"")
                .Find()
                .Select(p => p.Id)
                .Any(p => p == terminated.Id));            
        }

        [Test]
        public void find_all_employees_paged()
        {
            var emp = Api.Employees.Page(1).Find();
            Assert.Greater(emp.Count(), 0);
        }
    }
}
