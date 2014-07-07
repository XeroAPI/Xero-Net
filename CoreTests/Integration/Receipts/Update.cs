using System.Linq;
using NUnit.Framework;
using Xero.Api.Core.Model.Status;

namespace CoreTests.Integration.Receipts
{
    [TestFixture]
    public class Update : ReceiptTest
    {
        [Test]
        public void delete_receipt()
        {
            var contact = Random.GetRandomString(10);
            var description = Random.GetRandomString(30);
            const ReceiptStatus expected = ReceiptStatus.Deleted;
            const decimal value = 13.8m;

            var receipt = Given_a_receipt(Api.Users.Find().First().Id, contact, description, value, "420");
            receipt.Status = expected;
            var deletedReceipt = Api.Update(receipt);

            Assert.AreEqual(expected, deletedReceipt.Status);
        }
    }
}