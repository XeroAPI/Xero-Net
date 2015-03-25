using System;
using System.IO;

namespace CoreTests.Integration.Files.Support
{
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