using System;
using System.IO;
using System.Runtime.Serialization;
using Xero.Api.Common;

namespace Xero.Api.Core.File
{
    [DataContract(Namespace = "")]
    public class BinaryFile
    {
        private MemoryStream ContentStream { get; set; }

        public BinaryFile()
        {
        }

        public BinaryFile(FileInfo fileInfo)
        {
            if (fileInfo == null)
            {
                throw new ArgumentNullException("fileInfo");
            }
            if (!fileInfo.Exists)
            {
                throw new FileNotFoundException("The file could not be found", fileInfo.FullName);
            }

            using (FileStream fileStream = fileInfo.OpenRead())
            {
                CopyData(fileStream, fileInfo.Name, MimeTypes.GetMimeType(fileInfo), (int)fileInfo.Length);
            }
        }

        public BinaryFile(Stream content, string filename, string contentType, int length)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentNullException("filename");
            }

            CopyData(content, filename, contentType, length);
        }

        [DataMember]
        public string FileName { get; set; }

        [DataMember]
        public string MimeType { get; set; }

        [DataMember]
        public int ContentLength { get; set; }

        [DataMember]
        public byte[] Content
        {
            get { return ContentStream == null ? new byte[0] : ContentStream.ToArray(); }
        }

        public void Save(string fileName)
        {
            if (System.IO.File.Exists(fileName))
            {
                System.IO.File.Delete(fileName);
            }

            using (var file = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                ContentStream.Seek(0, SeekOrigin.Begin);
                file.Write(Content, 0, ContentLength);
            }
        }

        private void CopyData(Stream content, string filename, string contentType, int length)
        {
            FileName = filename;
            MimeType = contentType;
            ContentLength = length;

            ContentStream = new MemoryStream(ContentLength);
            content.CopyTo(ContentStream);
            ContentStream.Seek(0, SeekOrigin.Begin);
        }
    }
}