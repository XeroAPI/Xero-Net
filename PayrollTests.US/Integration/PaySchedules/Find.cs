using System;
using System.Linq;
using NUnit.Framework;

namespace PayrollTests.US.Integration.PaySchedules
{
    [TestFixture]
    public class Find : PaySchedulesTest
    {
        [Test]
        public void find_all()
        {
            Given_a_payschedule();
            var ps = Api.PaySchedules.Find();
            Assert.IsTrue(ps.FirstOrDefault().Id != Guid.Empty);
        }

        [Test]
        public void find_by_page()
        {
            Given_a_payschedule();
            var ps = Api.PaySchedules.Page(1).Find();
            Assert.IsTrue(ps.FirstOrDefault().Id != Guid.Empty);
        }

        [Test]
        public void find_by_id()
        {
            var ps_id = Given_a_payschedule().Id;
            var ps = Api.PaySchedules.Find(ps_id);
            Assert.AreEqual(ps_id, ps.Id);
        }
    }
}
