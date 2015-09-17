using System.Linq;
using NUnit.Framework;

namespace CoreTests.Integration.LinkedTransactions
{
    public class Find : LinkedTransactionTest
    {
        [Test]
        public void find_by_page()
        {
            Given_a_basic_linked_transaction();
            var linkedTransactions = Api.LinkedTransactions.Page(1).Find();

            Assert.Greater(linkedTransactions.Count(), 0);
        }

        [Test]
        public void find_by_id()
        {
            Given_a_basic_linked_transaction();
            var expected = LinkedTransactionId;

            var linkedTransaction = Api.LinkedTransactions.Find(expected);

            Assert.AreEqual(expected, linkedTransaction.Id);
        }

        [Test]
        public void find_by_source_transaction_id()
        {
            Given_a_basic_linked_transaction();
            var sourceTransactionId = SourceId;

            var linkedTransactions = Api.LinkedTransactions.WhereSourceId(sourceTransactionId).Find().ToList();
            
            Assert.Greater(linkedTransactions.Count(), 0);
            Assert.AreEqual(sourceTransactionId, linkedTransactions.First().SourceTransactionID);
        }

        [Test]
        public void find_by_contact_id()
        {
            Given_a_linked_transaction_assigned_to_a_contact();
            var contactId = ContactId;

            var linkedTransactions = Api.LinkedTransactions.WhereContactId(contactId).Find().ToList();

            Assert.Greater(linkedTransactions.Count(), 0);
            Assert.AreEqual(contactId, linkedTransactions.First().ContactID);
        }

        [Test]
        public void find_by_target_transaction_id()
        {
            Given_a_fully_allocated_linked_transaction();
            var targetTransactionId = TargetId;

            var linkedTransactions = Api.LinkedTransactions.WhereTargetId(targetTransactionId).Find().ToList();

            Assert.Greater(linkedTransactions.Count(), 0);
            Assert.AreEqual(targetTransactionId, linkedTransactions.First().TargetTransactionID);
        }
    }
}
