using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Types;

namespace CoreTests.Integration.Attachments
{
    public class Attachments : ApiWrapperTest
    {
        private const string ImagePath = @"resources\images\connect_xero_button_blue.png";

        [Test]
        public void adding_attachment_to_invoice()
        {
            var attachment = Given_attachment_on_invoice();
            
            Assert.IsTrue(attachment.Id != Guid.Empty);
        }

        [Test]
        public void listing_attachments()
        {
            var id = Given_invoice_with_no_attachments();
            CreateAttachment(id, AttachmentEndpointType.Invoices);

            var attachments = Api.Attachments.List(AttachmentEndpointType.Invoices, id).ToList();

            Assert.IsTrue(attachments.Any());
            Assert.IsTrue(attachments.First().Id != Guid.Empty);
        }

        [Test]
        public void getting_attachment()
        {
            var id = Given_invoice_with_no_attachments();
            var sourceFile = new FileInfo(ImagePath);

            var attachment = CreateAttachment(id, AttachmentEndpointType.Invoices, sourceFile);

            Assert.AreEqual(attachment.ContentLength, sourceFile.Length);
            Assert.AreEqual(attachment.FileName, sourceFile.Name);
        }

        [Test]
        public void saving_attachments()
        {
            var sourceFile = new FileInfo(ImagePath);

            var id = Given_invoice_with_no_attachments();
            var attachment = CreateAttachment(id, AttachmentEndpointType.Invoices);

            attachment = GetAttachment(id, AttachmentEndpointType.Invoices, attachment.FileName);
            
            var path = Path.GetTempFileName();
            attachment.Save(path);
            
            var targetFile = new FileInfo(path);

            Assert.AreEqual(sourceFile.Length, targetFile.Length);

            // Clean up after yourself!
            File.Delete(path);
        }

        [Test]
        public void saving_attachment_online_invoice()
        {
            var attachment = Given_attachment_on_invoice(true);
            
            Assert.AreEqual(true, attachment.IncludeOnline);
        }

        [Test]
        public void saving_attachment_online_credit_note()
        {
            var attachment = Given_attachment_on_credit_note(true);

            Assert.AreEqual(true, attachment.IncludeOnline);
        }

        private Attachment Given_attachment_on_invoice(bool includeOnline = false)
        {
            return CreateAttachment(Given_invoice_with_no_attachments(), AttachmentEndpointType.Invoices, includeOnline);
        }

        private Attachment Given_attachment_on_credit_note(bool includeOnline = false)
        {
            return CreateAttachment(Given_credit_note_with_no_attachments(), AttachmentEndpointType.CreditNotes, includeOnline);
        }


        private Attachment CreateAttachment(Guid id, AttachmentEndpointType type, bool includeOnline = false)
        {
            return CreateAttachment(id, type, new FileInfo(ImagePath), includeOnline);
        }

        private Attachment CreateAttachment(Guid id, AttachmentEndpointType type, FileInfo sourceFile, bool includeOnline = false)
        {
            return Api.Attachments.AddOrReplace(new Attachment(sourceFile), type, id, includeOnline);            
        }

        private Attachment GetAttachment(Guid id, AttachmentEndpointType type, string fileName)
        {
            return Api.Attachments.Get(type, id, fileName);
        }

        private Guid Given_invoice_with_no_attachments()
        {
            return Api.Create(new Invoice
            {
                Contact = new Contact { Name = "Richard" },
                Items = new List<LineItem>
                {
                    new LineItem
                    {
                        Description = "Nothing to see",
                        LineAmount = 100.0m
                    }
                }
            }).Id;
        }

        private Guid Given_credit_note_with_no_attachments()
        {
            return Api.CreditNotes.Create(new CreditNote
            {
                Contact = new Contact {Name = "Apple Computers Ltd"},
                Type = CreditNoteType.AccountsReceivable,
                LineAmountTypes = LineAmountType.Exclusive,
                LineItems = new List<LineItem>
                {
                    new LineItem
                    {
                        AccountCode = "720",
                        Description = "MacBook - White",
                        UnitAmount = 1995.00m
                    }
                }
            }).Id;
        }
    }
}
