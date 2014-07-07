using NUnit.Framework;

namespace PayrollTests.AU.Integration.PayItems
{
    [TestFixture]
    public class Find : ApiWrapperTest
    {
        [Test]
        public void find_all()
        {
            var items = Api.PayItems.Find();
            Assert.IsNotNull(items);
        }
    }
}
