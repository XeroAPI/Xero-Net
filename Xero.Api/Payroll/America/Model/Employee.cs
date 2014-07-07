using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Xero.Api.Common;
using Xero.Api.Payroll.America.Model.Types;
using Xero.Api.Payroll.Australia.Model.Status;

namespace Xero.Api.Payroll.America.Model
{
    [DataContract(Namespace = "")]
    public class Employee : HasUpdatedDate
    {
        [DataMember(Name = "EmployeeID", EmitDefaultValue = false)]
        public Guid Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public HomeAddress HomeAddress { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public DateTime? StartDate { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string JobTitle { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public EmploymentStatus Status { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Email { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public DateTime? DateOfBirth { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Gender { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public MailingAddress MailingAddress { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Phone { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string EmployeeNumber { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string SocialSecurityNumber { get; set; }

        [DataMember(Name = "PayScheduleID", EmitDefaultValue = false)]
        public Guid? PayScheduleId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string EmployeeGroupName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public EmploymentBasisType EmploymentBasis { get; set; }

        [DataMember(Name = "HolidayGroupID", EmitDefaultValue = false)]
        public Guid? HolidayGroupId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public bool IsAuthorisedToApproveTimeOff { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public bool IsAuthorisedToApproveTimesheets { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<SalaryAndWage> SalaryAndWages { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<WorkLocation> WorkLocations { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public PaymentMethod PaymentMethod { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public PayTemplate PayTemplate { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public OpeningBalances OpeningBalances { get; set; }        
    }
}
