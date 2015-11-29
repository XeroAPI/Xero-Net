using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Status;
using Xero.Api.Core.Model.Types;

namespace CoreTests.Integration.LinkedTransactions
{
    public abstract class LinkedTransactionTest : ApiWrapperTest
    {
        protected Invoice SourceInvoice { get; set; }
        protected Guid SourceId { get { return SourceInvoice.Id; } }
        protected Guid SourceLineItemId { get { return SourceInvoice.LineItems[0].LineItemId; } }

        protected Contact Contact { get; set; }
        protected Guid ContactId { get { return Contact.Id; } }

        protected Invoice TargetInvoice { get; set; }
        protected Guid TargetId { get { return TargetInvoice.Id; } }
        protected Guid TargetLineItemId { get { return TargetInvoice.LineItems[0].LineItemId; } }

        protected LinkedTransaction LinkedTransaction { get; set; }
        protected Guid LinkedTransactionId { get { return LinkedTransaction.Id; } }

        protected void Given_a_basic_linked_transaction()
        {
            Given_a_source_invoice();

            LinkedTransaction = Api.LinkedTransactions.Create(new LinkedTransaction
            {
                SourceTransactionID = SourceId,
                SourceLineItemID = SourceLineItemId
            });
        }

        protected void Given_a_linked_transaction_assigned_to_a_contact()
        {
            Given_a_source_invoice();
            Given_a_contact();

            LinkedTransaction = Api.LinkedTransactions.Create(new LinkedTransaction
            {
                SourceTransactionID = SourceId,
                SourceLineItemID = SourceLineItemId,
                ContactID = ContactId
            });
        }

        protected void Given_a_fully_allocated_linked_transaction()
        {
            Given_a_source_invoice();
            Given_a_contact();
            Given_a_target_invoice(Contact);

            LinkedTransaction = Api.LinkedTransactions.Create(new LinkedTransaction
            {
                SourceTransactionID = SourceId,
                SourceLineItemID = SourceLineItemId,
                ContactID = ContactId,
                TargetTransactionID = TargetId,
                TargetLineItemID = TargetLineItemId
            });
        }

        protected void Given_a_source_invoice()
        {
            SourceInvoice = Given_an_invoice();
        }

        protected void Given_a_target_invoice(Contact contact = null)
        {
            TargetInvoice = Given_an_invoice(InvoiceType.AccountsReceivable, contact: contact);
        }

        private Invoice Given_an_invoice(InvoiceType type = InvoiceType.AccountsPayable, InvoiceStatus status = InvoiceStatus.Authorised, decimal amount = 100m, string accountCode = "100", Contact contact = null)
        {
            if (contact == null)
                contact = new Contact {Name = "ABC Bank"};

            return Api.Create(new Invoice
            {
                Contact = contact,
                Type = type,
                Date = DateTime.UtcNow,
                DueDate = DateTime.UtcNow.AddDays(90),
                LineAmountTypes = LineAmountType.Inclusive,
                Status = status,
                LineItems = new List<LineItem>
                {
                    new LineItem
                    {
                        AccountCode = "200",
                        Description = "Good value item 1",
                        LineAmount = 100m
                    },
                    new LineItem
                    {
                        AccountCode = "200",
                        Description = "Good value item 2",
                        LineAmount = 100m
                    }
                }

            });
        }

        protected void Given_a_contact()
        {
            var contacts = Api.Contacts.Find().ToList();

            if (contacts.Any())
            {
                Contact = contacts.First();
            }

            Contact = Api.Contacts.Create(new Contact
            {
                Name = "Phil" + Guid.NewGuid().ToString("N")
            });
        }

        protected void Then_the_linked_transaction_has_an_id(LinkedTransaction linkedTransaction)
        {
            Assert.True(linkedTransaction.Id != Guid.Empty);
        }

        protected void Then_the_source_details_are_correct(LinkedTransaction linkedTransaction, Guid sourceId, Guid sourceLineItemId)
        {
            Assert.True(linkedTransaction.SourceTransactionID == sourceId);
            Assert.True(linkedTransaction.SourceLineItemID == sourceLineItemId);
        }

        protected void Then_the_target_details_are_correct(LinkedTransaction linkedTransaction, Guid targetId, Guid targetLineItemId)
        {
            Assert.True(linkedTransaction.TargetTransactionID == targetId);
            Assert.True(linkedTransaction.TargetLineItemID == targetLineItemId);
        }

        protected void Then_the_contact_details_are_correct(LinkedTransaction linkedTransaction, Guid contactId)
        {
            Assert.True(linkedTransaction.ContactID == contactId);
        }
    }
}