using System;
using System.Linq;
using NUnit.Framework;

namespace PayrollTests.AU.Integration.Settings
{
    [TestFixture]
    public class Find : ApiWrapperTest
    {
        [Test]
        public void find_all()
        {
            var settings = Api.Settings.Find();
            Assert.IsNotNull(settings);

            foreach (var s in settings)
            {
                Assert.True(s.Accounts.All(p => p.Id != Guid.Empty));
            }
        }
    }
}
