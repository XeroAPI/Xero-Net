using System;
using System.IO;
using System.Runtime.Serialization;
using Xero.Api.Common;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "")]
    public sealed class Attachment
    {
        private MemoryStream ContentStream { get; set; }

        public Attachment()
        {
        }

        public Attachment(FileInfo fileInfo)
        {
            if (fileInfo == null) { throw new ArgumentNullException("fileInfo"); }
            if (!fileInfo.Exists) { throw new FileNotFoundException("The file could not be found", fileInfo.FullName); }

            CopyData(fileInfo.OpenRead(), fileInfo.Name, MimeTypes.GetMimeType(fileInfo), (int)fileInfo.Length);            
        }

        public Attachment(Stream content, string filename, string contentType, int length)
        {
            if (content == null) { throw new ArgumentNullException("content"); }
            if (string.IsNullOrEmpty(filename)) { throw new ArgumentNullException("filename"); }

            CopyData(content, filename, contentType, length);
        }

        [DataMember(Name = "AttachmentID", EmitDefaultValue = false)]
        public Guid Id { get; set; }

        [DataMember]
        public string FileName { get; set; }

        [DataMember]
        public string MimeType { get; set; }

        [DataMember]
        public int ContentLength { get; set; }

        [DataMember]
        public byte[] Content
        {
            get
            {
                return ContentStream == null ? new byte[0] : ContentStream.ToArray();
            }
        }

        public void Save(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
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