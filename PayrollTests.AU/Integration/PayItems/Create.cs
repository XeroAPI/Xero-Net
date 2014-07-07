using System.Linq;
using NUnit.Framework;

namespace PayrollTests.AU.Integration.PayItems
{
    [TestFixture]
    public class Create : PayItemsTest
    {
        [Test]
        public void create_payitem()
        {
            var pi = Given_some_payitems();
            Assert.Contains("Ordinary Hours", pi.EarningsRates.Select(p => p.Name).ToList());
            Assert.Contains("Union Fees", pi.DeductionTypes.Select(p => p.Name).ToList());
            Assert.Contains("Annual Leave", pi.LeaveTypes.Select(p => p.Name).ToList());
            Assert.Contains("Travel National Costs", pi.ReimbursementTypes.Select(p => p.Name).ToList());
        }
    }
}
