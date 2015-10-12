using NUnit.Framework;
using Xero.Api.Infrastructure.Exceptions;

namespace CoreTests.Integration.LinkedTransactions
{
    public class Delete : LinkedTransactionTest
    {
        [Test]
        public void can_delete_linked_transactions()
        {
            Given_a_basic_linked_transaction();

            var id = LinkedTransactionId;

            Api.LinkedTransactions.Delete(LinkedTransaction);

            //After deleting the linked transaction, it no longer exists so we exopect to get a 404 NotFound when looking for it.
            Assert.Throws<NotFoundException>(() => Api.LinkedTransactions.Find(id));
        }
    }
}
