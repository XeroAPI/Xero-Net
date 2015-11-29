﻿using System.Runtime.Serialization;

namespace Xero.Api.Payroll.America.Model.Types
{
    [DataContract(Namespace = "")]
    public enum AccountType
    {
        [EnumMember(Value = "CHECKING")]
        Checking,
        [EnumMember(Value = "SAVING")]
        Saving
    }
}