using System;
using System.Linq;
using NUnit.Framework;

namespace CoreTests.Integration.BankTransactions
{
    [TestFixture]
    public class Find : BankTransactionTest
    {
        [Test]
        public void find_bank_transactions_where_filter()
        {
            Assert.DoesNotThrow(() => Api.BankTransactions
                .Where("Type == \"SPEND\"")
                .And("Status == \"AUTHORISED\"")
                .Find());
        }

        [Test]
        public void find_bank_transactions_ifmodifiedsince()
        {
            Given_a_bank_transaction();

            var bankTransaction = Api.BankTransactions
                .ModifiedSince(DateTime.Today.AddDays(-1).Date)
                .Find();

            Assert.IsNotNull(bankTransaction);
        }

        [Test]
        public void find_bank_transactions_individual()
        {
            var expected = Given_a_bank_transaction().Id;

            var id = Api.BankTransactions.Find(expected).Id;

            Assert.AreEqual(expected, id);
        }

        [Test]
        public void find_by_page()
        {
            Given_a_bank_transaction();
            var bankTrans = Api.BankTransactions.Page(1).Find();

            Assert.Greater(bankTrans.Count(), 0);
        }
    }
}
