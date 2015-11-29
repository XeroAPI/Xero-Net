﻿using System.Runtime.Serialization;

namespace Xero.Api.Payroll.America.Model.Types
{
    [DataContract]
    public enum PaymentMethodType
    {
        [EnumMember(Value = "CHECK")]
        Check,
        [EnumMember(Value = "MANUAL")]
        Manual,
        [EnumMember(Value = "DIRECTDEPOSIT")]
        DirectDeposit
    }
}