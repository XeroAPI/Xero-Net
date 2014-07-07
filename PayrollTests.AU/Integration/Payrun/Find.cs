using System;
using System.Linq;
using NUnit.Framework;

namespace PayrollTests.AU.Integration.Payrun
{
    [TestFixture]
    public class Find : PayrunTest
    {
        [Test]
        public void find_all()
        {
            Given_a_payrun();
            var payruns = Api.PayRuns.Find();
            Assert.IsNotNull(payruns);
            Assert.IsTrue(payruns.FirstOrDefault().Id != Guid.Empty);
        }


        [Test]
        public void find_by_id()
        {
            var the_pr_id = Given_a_payrun().Id;
            var payrun = Api.PayRuns.Find(the_pr_id);
            Assert.AreEqual(the_pr_id, payrun.Id);
        }
    }
}
