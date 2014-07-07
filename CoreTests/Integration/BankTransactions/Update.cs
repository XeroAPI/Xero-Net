using System.Collections.Generic;
using NUnit.Framework;
using Xero.Api.Core.Model;

namespace CoreTests.Integration.BankTransactions
{
    [TestFixture]
    public class Update : BankTransactionTest
    {
        [Test]
        public void update_bank_transaction()
        {
            var bt = Given_a_bank_transaction();

            var updatedTransaction = Api.Update(new BankTransaction
            {
                Id = bt.Id,
                BankAccount = new Account { Id = FindBankAccountGuid() },
                LineItems = new List<LineItem>
                    {
                        new LineItem
                        {
                            UnitAmount = 100m,
                            Quantity = 2m,
                            Description = bt.LineItems[0].Description,
                            AccountCode = bt.LineItems[0].AccountCode
                        }
                    }
            });

            Assert.AreEqual(100, updatedTransaction.LineItems[0].UnitAmount);
            Assert.AreEqual(2, updatedTransaction.LineItems[0].Quantity);
            Assert.AreEqual(200, updatedTransaction.LineItems[0].LineAmount);
        }
    }
}
