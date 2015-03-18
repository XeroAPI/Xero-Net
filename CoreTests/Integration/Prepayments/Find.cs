using System.Linq;
using NUnit.Framework;

namespace CoreTests.Integration.Prepayments
{
    [TestFixture]
    public class Find : ApiWrapperTest
    {
        [Test]
        public void find_all()
        {
            var prepayments = Api.Prepayments.Find();
            Assert.Greater(prepayments.Count(), 0);
        }
    }
}
