using System;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Types;

namespace CoreTests.Integration.Files.Associations
{
    [TestFixture]
    public class AssociationTest : ApiWrapperTest
    {
        private Guid FindAFileId()
        {
            var file = Api.Files.Find().FirstOrDefault();
            return file == null ? Guid.Empty : file.Id;
        }

        private Guid FindAnInvoiceId()
        {
            var invoice = Api.Invoices.Find().FirstOrDefault();
            return invoice == null ? Guid.Empty : invoice.Id;
        }

        [Test]
        public void AssociationsForFile()
        {
            Assert.DoesNotThrow(() =>
            {
                var fileId = FindAFileId();
                var list = Api.Associations.Find(fileId);
                Debug.WriteLine("Found {0} associations for file {1}.", list.Count(), fileId);
            });
        }

        [Test]
        public void AssociationsForObject()
        {
            Assert.DoesNotThrow(() =>
            {
                var objectId = FindAnInvoiceId();
                var list = Api.Associations.FindForObject(objectId);
                Debug.WriteLine("Found {0} associations for object {0}.", list.Count(), objectId);
            });
        }

        // This is not a great test - but it needs to run in sequence and clean up after itself
        // (if it happens to be working with an association that should already exist, then we have a problem...)
        [Test]
        public void AssociationCreateFindAndDelete()
        {
            var fileId = FindAFileId();
            var objectId = FindAnInvoiceId();

            Assert.DoesNotThrow(() =>
            {
                var toCreate = new Association
                {
                    FileId = fileId,
                    ObjectId = objectId,
                    ObjectGroup = ObjectGroupType.Invoice
                };
                var created = Api.Associations.Create(toCreate);
                Debug.WriteLine("Created {0}", created);
            });

            Assert.DoesNotThrow(() =>
            {
                var found = Api.Associations.Find(fileId, objectId);
                Debug.WriteLine("Found {0}", found);
            });

            Assert.DoesNotThrow(() =>
            {
                var toDelete = new Association
                {
                    FileId = fileId,
                    ObjectId = objectId,
                    ObjectGroup = ObjectGroupType.Invoice
                };
                Api.Associations.Delete(toDelete);
                Debug.WriteLine("Deleted {0}", toDelete);
            });
        }
    }
}