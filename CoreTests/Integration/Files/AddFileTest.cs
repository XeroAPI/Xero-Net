using System.Linq;
using NUnit.Framework;
using Xero.Api.Core.Model;
using Xero.Api.Core.Response;

namespace CoreTests.Integration.Files
{
    [TestFixture]
    public class AddFileTest : FilesTest
    {
        private const string ImagePath = @"connect_xero_button_blue.png";

        public string Id;

        public string inboxFolderId;

       

        public AddFileTest()
        {
            exampleFile = GetFileBytes("xero", ImagePath);

        }

        private void for_example()
        {
            var result = Api.Files.All();

            inboxFolderId = result[0].FolderId;

            Id = result[0].Id;
        }

        [Test]
        public void can_get_all_files_like_this()
        {
            var result = Api.Files.All();

            Assert.True(result != null);
        }

        [Test]
        public void can_get_the_content_of_a_file_like_this()
        {
            for_example();

            var folder = Api.Files[inboxFolderId];

            var file = folder[Id];

        }


        [Test]
        public void can_get_single_file_like_this()
        {
            for_example();

            var files = Api.Files[inboxFolderId];

            var file = files[Id];

            Assert.IsTrue(file.Name == "test");

            Assert.IsTrue(files.Name == "Inbox");
        }

        [Test]
        public void can_get_all_folders_like_this()
        {

            var allFolders = Api.Files.Folders;

            Assert.True(allFolders.Count() == 2);

            Assert.True(allFolders[0].Name == "Inbox");

            Assert.True(allFolders[1].Name == "Contracts");

        }

        [Test]
        public void can_get_the_inbox_like_this()
        {
            var inbox = Api.Files.Inbox;

            Assert.IsTrue(inbox.Name == "Inbox");

            Assert.IsTrue(inbox.IsInbox);
        }


        [Test]
        public void Can_add_a_file_to_inbox_like_this()
        {

            var inbox = Api.Files.Inbox;

            var result = Given_a_file(inbox);

            Assert.IsTrue(result != null);
        }

       

        [Test]
        public void can_remove_a_file_like_this()
        {
            var inbox = Api.Files.Inbox;

            var result = Given_a_file(inbox);

            Api.Files.Remove(result.Id);

        }
        
    }

}
