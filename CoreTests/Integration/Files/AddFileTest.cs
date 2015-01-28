using System;
using NUnit.Framework;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Exceptions;

namespace CoreTests.Integration.Files
{
    [TestFixture]
    public class AddFileTest : FilesTest
    {
        public Guid id;

        public Guid inboxFolderId;
        
        [Test]
        public void can_get_all_files_like_this()
        {
            var result = Api.Files.Find();

            Assert.True(result != null);
        }

        [Test]
        public void can_get_the_content_of_a_file_like_this()
        {

            var filename = "My Test File " + Guid.NewGuid();

            var inboxId = Api.Inbox.InboxFolder.Id;

            var id = Given_a_file_in(inboxId, filename);

            var resultingFile = Api.Files[id];

            Assert.IsTrue(resultingFile.Name == filename);

        }
        
       [Test]
        public void can_remove_a_file_like_this()
        {
            var inboxId = Api.Inbox.InboxFolder.Id;

            var result = Given_a_file_in(inboxId, "Test " + Guid.NewGuid());

            Api.Files.Remove(result);

            var notfound= Api.Files[result];  

            Assert.IsNull(notfound);

        }
    }

}
