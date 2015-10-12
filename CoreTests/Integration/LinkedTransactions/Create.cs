using NUnit.Framework;
using Xero.Api.Core.Model;

namespace CoreTests.Integration.LinkedTransactions
{
    public class Create : LinkedTransactionTest
    {
        [Test]
        public void can_create_a_linked_transaction_with_just_source_details()
        {
            Given_a_source_invoice();
            
            var linkedTransaction = Api.LinkedTransactions.Create(new LinkedTransaction
            {
                SourceTransactionID = SourceId,
                SourceLineItemID = SourceLineItemId
            });

            Then_the_linked_transaction_has_an_id(linkedTransaction);
            Then_the_source_details_are_correct(linkedTransaction, SourceId, SourceLineItemId);
        }

        

        [Test]
        public void can_create_a_linked_transaction_with_source_details_assigned_to_a_Contact()
        {
            Given_a_contact();
            Given_a_source_invoice();

            var linkedTransaction = Api.LinkedTransactions.Create(new LinkedTransaction
            {
                SourceTransactionID = SourceId,
                SourceLineItemID = SourceLineItemId,
                ContactID = ContactId
            });

            Then_the_linked_transaction_has_an_id(linkedTransaction);
            Then_the_source_details_are_correct(linkedTransaction, SourceId, SourceLineItemId);
            Then_the_contact_details_are_correct(linkedTransaction, ContactId);
        }

        [Test]
        public void can_create_a_fully_allocated_linkedTransaction()
        {
            Given_a_contact();

            Given_a_source_invoice();

            Given_a_target_invoice(Contact);


            var linkedTransaction = Api.LinkedTransactions.Create(new LinkedTransaction
            {
                SourceTransactionID = SourceId,
                SourceLineItemID = SourceLineItemId,
                ContactID = ContactId,
                TargetTransactionID = TargetId,
                TargetLineItemID = TargetLineItemId
            });

            Then_the_linked_transaction_has_an_id(linkedTransaction);
            Then_the_source_details_are_correct(linkedTransaction, SourceId, SourceLineItemId);
            Then_the_contact_details_are_correct(linkedTransaction, ContactId);
            Then_the_target_details_are_correct(linkedTransaction, TargetId, TargetLineItemId);
        }

    }
}
