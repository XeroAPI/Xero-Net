using System;
using System.IO;
using System.Runtime.Serialization;
using Xero.Api.Common;
using Xero.Api.Core.File;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "")]
    public sealed class Attachment : BinaryFile, IHasId
    {
        public Attachment(FileInfo fileInfo) : base(fileInfo)
        {
        }

        public Attachment(Stream content, string filename, string contentType, int length)
            : base(content, filename, contentType, length)
        {
        }

        [DataMember(Name = "AttachmentID", EmitDefaultValue = false)]
        public Guid Id { get; set; }

        [DataMember]
        public bool IncludeOnline { get; set; }        
    }
}