using System.Linq;
using NUnit.Framework;

namespace CoreTests.Integration.Overpayments
{
    [TestFixture]
    public class Find : ApiWrapperTest
    {
        [Test]
        public void find_all()
        {
            var overpayments = Api.Overpayments.Find();
            Assert.Greater(overpayments.Count(), 0);
        }
    }
}
