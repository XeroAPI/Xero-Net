﻿using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Status
{
    [DataContract(Namespace = "")]
    public enum ManualJournalStatus
    {
        [EnumMember(Value = "DRAFT")]
        Draft,
        [EnumMember(Value = "POSTED")]
        Posted,
        [EnumMember(Value = "DELETED")]
        Deleted,
        [EnumMember(Value = "VOIDED")]
        Voided
    }
}