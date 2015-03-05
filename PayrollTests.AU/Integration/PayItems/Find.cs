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

        [Test]
        public void find_paged()
        {
            var items = Api.PayItems.Page(1).Find();
            Assert.IsNotNull(items);
        }
    }
}
