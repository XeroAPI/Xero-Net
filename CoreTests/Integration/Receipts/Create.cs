using System.Linq;
using NUnit.Framework;

namespace CoreTests.Integration.Receipts
{
    [TestFixture]
    public class Create : ReceiptTest
    {
        [Test]
        public void create_receipt()
        {
            var contact = Random.GetRandomString(10);
            var description = Random.GetRandomString(30);
            const decimal value = 13.8m;

            var receipt = Given_a_receipt(Api.Users.Find().First().Id, contact, description, value, "420");

            Assert.AreEqual(receipt.Total, value);
            Assert.AreEqual(receipt.Contact.Name, contact);
            Assert.AreEqual(receipt.LineItems[0].Description, description);
        }
    }
}

