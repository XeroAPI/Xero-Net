using System;
using System.Net;
using NUnit.Framework;
using Xero.Api.Core.Model;
using Xero.Api.Core.Response;

namespace CoreTests.Integration.Files
{
    public class AddFolderTest : FilesTest
    {

        [Test]
        public void can_create_a_folder_like_this()
        {
            var result = Api.Folders.Add("Test Folder" + Guid.NewGuid());
        }


        [Test]
        public void can_get_all_folders_like_this()
        {

            var allFolders = Api.Folders.Folders;

            //Assert.True(allFolders.Count() == 2);

            Assert.True(allFolders[0].Name == "Inbox");

            Assert.True(allFolders[1].Name == "Contracts");

        }

      }
}