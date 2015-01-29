using System;
using System.Linq;
using System.Net;
using NUnit.Framework;
using Xero.Api.Core.Model;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Exceptions;

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

            Assert.True(allFolders[0].Name == "Inbox");

            Assert.True(allFolders[1].Name == "Contracts");

        }

        [Test]
        public void can_remove_a_folder_like_this()
        {

            var folder = Api.Folders.Add("Test Folder" + Guid.NewGuid());

            Api.Folders.Remove(folder.Id); // Hint ->folder is empty

        }
        
      }
}