using System;
using System.Linq;
using NUnit.Framework;

namespace CoreTests.Integration.BankTransfers
{
    [TestFixture]
    public class Find : BankTransfersTest
    {
        [Test]
        public void find_bank_transfers()
        {
            Given_a_bank_transfer(10m);

            var allTransfers = Api.BankTransfers.Find();

            Assert.Greater(allTransfers.Count(), 0);
        }

        [Test]
        public void find_bank_transfers_individual()
        {
            var expected = Given_a_bank_transfer(25m).Id;

            var id = Api.BankTransfers.Find(expected).Id;

            Assert.AreEqual(expected, id);
        }

        [Test]
        public void find_bank_transfers_ifmodifiedsince()
        {
            Given_a_bank_transfer(25m);

            var date = DateTime.Today.AddDays(-4);
            var bankTransfers = Api.BankTransfers.ModifiedSince(date).Find();

            Assert.Greater(bankTransfers.Count(), 0);
        }
    }
}
