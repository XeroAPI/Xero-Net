using System;
using System.Linq;
using System.Net;
using System.Runtime.Remoting;
using NUnit.Framework;
using Xero.Api.Core.Model;

namespace CoreTests.Integration.Files
{
    [TestFixture]
    public class InboxTest : FilesTest
    {

        [Test]
        public void can_get_the_inbox_like_this()
        {
            var inbox = Api.Inbox.InboxFolder;

            Assert.IsTrue(inbox.Name == "Inbox");

            Assert.IsTrue(inbox.IsInbox);
        }

        [Test]
        public void Can_add_a_file_to_inbox_like_this()
        {
            var filename = "Inbox file " + Guid.NewGuid();

            var result = Api.Inbox.Add(create_file_with_name(filename), exampleFile);

            var file = Api.Files[result.Id];

            Assert.IsTrue(file.Mimetype == "image/png");
            Assert.IsTrue(file.Name == filename);

        }

        [Test]
        public void can_remove_a_file_like_this()
        {
            var inboxId = Api.Inbox.InboxFolder.Id;

            var result = Given_a_file_in(inboxId, "Test " + Guid.NewGuid());

            Api.Inbox.Remove(result);

            var notfound = Api.Inbox[result];

            Assert.IsNull(notfound);

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