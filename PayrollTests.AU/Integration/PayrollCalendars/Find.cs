using System;
using System.Linq;
using NUnit.Framework;

namespace PayrollTests.AU.Integration.PayrollCalendars
{
    [TestFixture]
    public class Find : ApiWrapperTest
    {
        [Test]
        public void find_all()
        {
            var prc = Api.PayrollCalendars.Find();
            Assert.True(prc.Any());
            Assert.True(prc.FirstOrDefault().Id != Guid.Empty);
        }
    }
}
