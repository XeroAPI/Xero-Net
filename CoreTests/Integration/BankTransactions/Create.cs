using NUnit.Framework;

namespace CoreTests.Integration.BankTransactions
{
    [TestFixture]
    public class Create : BankTransactionTest
    {
        [Test]
        public void create_bank_transactions()
        {
            var name = Given_a_bank_transaction()
                .Contact
                .Name;

            Assert.AreEqual("ABC Bank", name);
        }
    }
}
