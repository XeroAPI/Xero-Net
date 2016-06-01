using System;
using System.Runtime.Serialization;
using Xero.Api.Core.Model.Types;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "")]
    public class Association
    {
        [DataMember(EmitDefaultValue = false, IsRequired = false)]
        public Guid FileId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Guid ObjectId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public ObjectGroupType ObjectGroup { get; set; }

        [DataMember(EmitDefaultValue = false, IsRequired = false)]
        public ObjectType ObjectType { get; set; }

        public override string ToString()
        {
            return "Association: FileId=" + FileId + ", ObjectId=" + ObjectId;
        }
    }
}