﻿using System.Runtime.Serialization;

namespace Xero.Api.Payroll.America.Model.Types
{
    [DataContract(Namespace = "")]
    public enum SalaryWagesType
    {
        [EnumMember(Value = "HOURLY")]
        Hourly,
        [EnumMember(Value = "SALARY")]
        Salary
    }
}