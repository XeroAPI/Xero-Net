using System.Linq;
using NUnit.Framework;
using Xero.Api.Core.Model.Types;

namespace CoreTests.Integration.Accounts
{
    [TestFixture]
    public class Find : ApiWrapperTest
    {
        [Test]
        public void find_by_value()
        {
            var type = Api.Accounts
                .Where("Type == \"OVERHEADS\"")
                .Find()
                .ToList().First().Type;

            Assert.AreEqual(AccountType.Overheads, type);
        }

        [Test]
        public void find_by_id()
        {
            var expected = Api.Accounts
                .Where("Type == \"REVENUE\"")
                .Find()
                .First()
                .Id;

            var id = Api.Accounts.Find(expected).Id;
            
            Assert.AreEqual(expected, id);
        }
    }
}
