using System;
using System.Runtime.Serialization;
using Xero.Api.Common;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "", Name = "HistoryRecord")]
    public class History : CoreData
    {
        [IgnoreDataMember]
        [DataMember]
        public string Changes { get; set; }

        [IgnoreDataMember]
        [DataMember(Name = "DateUTCString", EmitDefaultValue = false)]
        public string DateUtcString { get; set; }

        [IgnoreDataMember]
        [DataMember(Name = "DateUTC", EmitDefaultValue = false)]
        public DateTime? DateUtc { get; set; }

        [IgnoreDataMember]
        [DataMember(EmitDefaultValue = false)]
        public string User { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Details { get; set; }
    }
}