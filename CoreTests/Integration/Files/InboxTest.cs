using System;
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
            Api.Inbox.Add("image/jpg", create_file_with_name("Inbox file " + Guid.NewGuid()), exampleFile);
        }

        private File create_file_with_name(string filename)
        {
            return new Xero.Api.Core.Model.File()
            {
                Name = filename,
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