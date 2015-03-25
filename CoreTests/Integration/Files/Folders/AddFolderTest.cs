using System;
using CoreTests.Integration.Files.Support;
using NUnit.Framework;

namespace CoreTests.Integration.Files.Folders
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