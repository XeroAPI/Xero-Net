using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xero.Api.Core.Model;
using File = System.IO.File;

namespace CoreTests.Integration.Files
{
    [TestFixture]
    public class Add_file : ApiWrapperTest
    {
        private const string ImagePath = @"connect_xero_button_blue.png";
        
        public string Id;
        
        public string folderId;

        [Test]
        public void can_get_all_files_like_this()
        {
           var result= Api.Files.All();

            Assert.True(result!=null);
        }

        [Test]
        public void can_get_the_content_of_a_file_like_this()
        {
            for_example();

            var folder = Api.Files[folderId];

            var file = folder[Id];

        }


        [Test]
        public void can_get_single_file_like_this()
        {
            for_example();

            var folder = Api.Files[folderId];
            
            var file = folder[Id];

            Assert.IsTrue(file.Name == "10322846_10154310023545529_6907991459304884147_n.jpg");

            //Assert.IsTrue(folder.IsInbox );
            
            Assert.IsTrue(folder.Name == "Inbox");

        }


        [Test]
        public void can_get_all_folders_like_this()
        {

            var allFolders = Api.Files.Folders;

            Assert.True(allFolders.Count()==2);

            Assert.True(allFolders[0].Name =="Inbox");

            Assert.True(allFolders[1].Name == "Contracts");

        }

        [Test]
        public void can_get_the_inbox_like_this()
        {
            var inbox = Api.Files.Inbox;

            Assert.IsTrue(inbox.Name == "Inbox");

            Assert.IsTrue(inbox.IsInbox);
        }


        private void for_example()
        {
            var result = Api.Files.All();

            folderId = result[0].FolderId;

            Id = result[0].Id;
        }


        [Test]
        public void Can_add_a_file_like_this()
        {
            var data = GetFileBytes("xero",ImagePath);


            var result = Api.Files.Add(new Xero.Api.Core.Model.File()
            {
                Name = "test",
                User = new FilesUser()
                {
                    FirstName = "David",
                    LastName = "Norden",
                    FullName = "David Norden",
                    Name = "David@gmail.com"

                }
            }, data);
        }

      

        protected static byte[] GetFileBytes(string name, string fileName)
        {
            var file = new FileInfo(new DiskFile(name, fileName).Path);

            var data = new DataItem(file);
            byte[] bytes;

            using (var ms = new MemoryStream())
            {
                data.Content.CopyTo(ms);
                bytes = ms.ToArray();
            }

            return bytes;
        }
    }

    public class DiskFile : File
    {
        public string Name { get; private set; }
        public string Path { get; private set; }
        public int ContentLength { get; private set; }

        public DiskFile(string name)
            : this(name, name)
        { }

        public DiskFile(string name, string path)
        {
            Name = name;
            Path = string.Format("resources\\images\\{0}", path);
            ContentLength = (int)new FileInfo(Path).Length;
        }
    }
    
    public interface File
    {
        string Name { get; }
        string Path { get; }
        int ContentLength { get; }
    }

    public class DataItem : IDisposable
    {
        public String ContentType { get; set; }
        public Stream Content { get; private set; }

        public DataItem(FileInfo file, String contentType = "unknown")
        {
            Content = file.OpenRead();
            ContentType = contentType;
        }

        public DataItem(Byte[] data, String contentType = "unknown")
        {
            ContentType = contentType;
            Content = new MemoryStream(data);
        }

        public void Dispose()
        {
            if (Content != null)
            {
                Content.Close();
            }
        }
    }
}
