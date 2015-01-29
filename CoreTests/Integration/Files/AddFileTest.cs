using System;
using System.Net;
using NUnit.Framework;
using Xero.Api.Core.Model;

namespace CoreTests.Integration.Files
{
    [TestFixture]
    public class AddFileTest : FilesTest
    {
      
        
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

       [Test]
       public void can_rename_a_file_like_this()
       {
           var inboxId = Api.Inbox.InboxFolder.Id;

           var result = Given_a_file_in(inboxId, "Test " + Guid.NewGuid());

           var copy = Api.Files[result];

           var NewName = "someother name";

           var updateResult = Api.Files.Rename(copy.Id, NewName);

           Assert.IsTrue(updateResult.Name == NewName);

       }

       [Test]
       public void can_move_a_file_like_this()
       {
           var inboxId = Api.Inbox.InboxFolder.Id;

           var result = Given_a_file_in(inboxId, "Test " + Guid.NewGuid());

           var newFolder = Api.Folders.Add("stuff");

           var updateResult = Api.Files.Move(result, newFolder.Id);

           Assert.IsTrue(updateResult.FolderId == newFolder.Id);

       }
        
       [Test]
       public void Cannot_add_a_file_with_bad_filename_charactors()
       {
           var inboxId = Api.Inbox.InboxFolder.Id;

           char[] badchar = System.IO.Path.GetInvalidFileNameChars();

           var filename = "Inbox file " + badchar[0] + badchar[3] + badchar[2];

           Assert.Throws<WebException>(() =>
           {
               Api.Files.Add( inboxId, create_file_with_name(filename), exampleFile);
           });
       }

       private File create_file_with_name(string filename)
       {
           return new Xero.Api.Core.Model.File()
           {
               Name = filename,
               FileName = filename,
               Mimetype = "image/png",
               User = new FilesUser()
               {
                   FirstName = "Bart",
                   LastName = "Simpson",
                   FullName = "Bart Simpson",
                   Name = "Bart@gmail.com"
               }
           };
       }
    }

}
