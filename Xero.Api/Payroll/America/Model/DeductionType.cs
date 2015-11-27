﻿using System;
using System.Runtime.Serialization;
using Xero.Api.Common;
using Xero.Api.Payroll.America.Model.Types;

namespace Xero.Api.Payroll.America.Model
{
    [DataContract(Namespace = "")]
    public class DeductionType : HasUpdatedDate
    {
        [DataMember(Name = "DeductionTypeID")]
        public Guid Id { get; set; }
        
        [DataMember(Name = "DeductionType")]
        public string Name { get; set; }
        
        [DataMember]
        public DeductionCategoryType DeductionCategory { get; set; }

        [DataMember]
        public CalculationType CalculationType { get; set; }

        [DataMember]
        public string LiabilityAccountCode { get; set; }

        [DataMember]
        public decimal StandardAmount { get; set; }

        [DataMember]
        public decimal CompanyMax { get; set; }
    }
}