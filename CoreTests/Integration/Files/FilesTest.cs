using System.IO;
using CoreTests.Integration.Files.Support;
using Xero.Api.Core.Model;
using Xero.Api.Core.Response;

namespace CoreTests.Integration.Files
{
    public class FilesTest : ApiWrapperTest
    {
        protected byte[] exampleFile;

        protected FilesResponse Given_a_file(InboxResponse inbox)
        {
            var result = Api.Files.Add(inbox.Id, "image/jpg", new Xero.Api.Core.Model.File()
            {
                Name = "test",
                User = new FilesUser()
                {
                    FirstName = "David",
                    LastName = "Norden",
                    FullName = "David Norden",
                    Name = "David@gmail.com"
                }
            }, exampleFile);
            return result;
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