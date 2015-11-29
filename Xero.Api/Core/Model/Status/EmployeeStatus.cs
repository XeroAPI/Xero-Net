﻿using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Status
{
    [DataContract(Namespace = "")]
    public enum EmployeeStatus
    {
        [EnumMember(Value = "ACTIVE")]
        Active,
        [EnumMember(Value = "DELETED")]
        Deleted
    }
}