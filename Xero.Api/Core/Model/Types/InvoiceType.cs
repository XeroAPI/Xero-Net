﻿using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Types
{
    [DataContract(Namespace = "")]
    public enum InvoiceType
    {
        [EnumMember(Value = "ACCPAY")]
        AccountsPayable,
        [EnumMember(Value = "ACCREC")]
        AccountsReceivable        
    }
}