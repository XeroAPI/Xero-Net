using System;
using System.IO;
using System.Net.Configuration;
using System.Runtime.CompilerServices;
using CoreTests.Integration.Files.Support;
using Xero.Api.Core.Model;
using Xero.Api.Core.Response;
using File = Xero.Api.Core.Model.File;

namespace CoreTests.Integration.Files
{
    public class FilesTest : ApiWrapperTest
    {
        protected byte[] exampleFile;
        private const string ImagePath = @"connect_xero_button_blue.png";

        public FilesTest()
        {
            exampleFile = GetFileBytes("xero", ImagePath);
        }
        
        private File create_file_with_name(string filename)
        {
            return new Xero.Api.Core.Model.File()
            {
                Name = filename,
                FileName = filename,
                User = new FilesUser()
                {
                    FirstName = "Bart",
                    LastName = "Simpson",
                    FullName = "Bart Simpson",
                    Name = "Bart@gmail.com"
                }
            };
        }

        protected Guid Given_a_file_in(Guid folderId, string filename)
        {
            var file = create_file_with_name(filename);

            return Given_a_file_in(folderId, file);

        }

        protected Guid Given_a_file_in(Guid folderId)
        {
            var filename = "Test" + Guid.NewGuid() + ".png";

            return Given_a_file_in(folderId, create_file_with_name(filename));    
        }

        protected Guid Given_a_file_in(Guid folderId,File file )
        {
            var result = Api.Files.Add(folderId, file, exampleFile);

            return result.Id ;
        }
        
        internal static byte[] GetFileBytes(string name, string fileName)
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
}