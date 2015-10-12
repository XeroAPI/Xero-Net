using System;
using System.Runtime.Serialization;
using Xero.Api.Common;
using Xero.Api.Core.Model.Status;
using Xero.Api.Core.Model.Types;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "")]
    public class LinkedTransaction : HasUpdatedDate, IHasId
    {
        [DataMember(Name = "LinkedTransactionID", EmitDefaultValue = false)]
        public Guid Id { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Guid SourceTransactionID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Guid SourceLineItemID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Guid ContactID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Guid TargetTransactionID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Guid TargetLineItemID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public LinkedTransactionStatus Status { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public LinkedTransactionType Type { get; set; }

    }
}
