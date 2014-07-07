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
            var invoiceId = Given_invoice_with_no_attachments();

            var newAttachment = new Attachment(new FileInfo(ImagePath));
            var attachment = Api.Attachments.AddOrReplace(newAttachment, AttachmentEndpointType.Invoices, invoiceId);

            Assert.IsTrue(attachment.Id != Guid.Empty);
        }

        [Test]
        public void listing_attachments()
        {
            var invoiceId = Given_invoice_with_no_attachments();

            Api.Attachments.AddOrReplace(new Attachment(new FileInfo(ImagePath)), AttachmentEndpointType.Invoices, invoiceId);

            var attachments = Api.Attachments.List(AttachmentEndpointType.Invoices, invoiceId).ToList();

            Assert.IsTrue(attachments.Any());
            Assert.IsTrue(attachments.First().Id != Guid.Empty);
        }

        [Test]
        public void getting_attachment()
        {
            var invoiceId = Given_invoice_with_no_attachments();
            var sourceFile = new FileInfo(ImagePath);
            var newAttachment = Api.Attachments.AddOrReplace(new Attachment(sourceFile), AttachmentEndpointType.Invoices, invoiceId);
            var attachment = Api.Attachments.Get(AttachmentEndpointType.Invoices, invoiceId, newAttachment.FileName);

            Assert.AreEqual(attachment.ContentLength, sourceFile.Length);
            Assert.AreEqual(attachment.FileName, sourceFile.Name);
        }

        [Test]
        public void saving_attachments()
        {
            var invoiceId = Given_invoice_with_no_attachments();

            var sourceFile = new FileInfo(ImagePath);
            var newAttachment = Api.Attachments.AddOrReplace(new Attachment(sourceFile), AttachmentEndpointType.Invoices, invoiceId);
            var attachment = Api.Attachments.Get(AttachmentEndpointType.Invoices, invoiceId, newAttachment.FileName);
            var path = Path.GetTempFileName();

            attachment.Save(path);

            var targetFile = new FileInfo(path);

            Assert.AreEqual(sourceFile.Length, targetFile.Length);
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
    }
}
