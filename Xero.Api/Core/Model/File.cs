using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "")]
    public class File
    {
        [DataMember(EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Id { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string FolderId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Mimetype { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public long Size { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public DateTime CreatedDateUtc { get; set; }
        
        [DataMember(EmitDefaultValue = false)]
        public DateTime UpdatedDateUtc { get; set; }

        public Model.FilesUser User { get; set; }
   }

    [DataContract(Namespace = "")]
    public class Folder
    {
        [DataMember(EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Guid Id { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public FilePage Files { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public bool IsInbox { get; set; }
        

    }

    [DataContract(Namespace = "")]
    public class FilePage
    {
        [DataMember(EmitDefaultValue = false)]
        public List<File> Items { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public long TotalCount { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public long Page { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public long PerPage { get; set; }

    }


    [DataContract(Namespace = "")]
    public class FilesUser
    {
        [DataMember(EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string FirstName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string LastName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string FullName { get; set; }


    }
}