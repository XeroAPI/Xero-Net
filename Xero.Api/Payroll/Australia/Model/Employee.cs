using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Xero.Api.Common;
using Xero.Api.Payroll.Australia.Model.Status;

namespace Xero.Api.Payroll.Australia.Model
{
    [DataContract(Namespace = "")]
    public class Employee : HasUpdatedDate
    {
        [DataMember(Name = "EmployeeID", EmitDefaultValue = false)]
        public Guid Id { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Title { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string MiddleNames { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public DateTime? DateOfBirth { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Gender { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public HomeAddress HomeAddress { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Phone { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Mobile { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string TwitterUserName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Email { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public DateTime? StartDate { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public DateTime? TerminationDate { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public EmploymentStatus Status { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Classification { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string EmployeeGroupName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Occupation { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public bool IsAuthorisedToApproveLeave { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public bool IsAuthorisedToApproveTimesheets { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Guid? OrdinaryEarningsRateID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string OrdinaryEarningsRateName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Guid? PayrollCalendarID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string PayrollCalendarName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<BankAccount> BankAccounts { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public PayTemplate PayTemplate { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public OpeningBalances OpeningBalances { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<LeaveBalance> LeaveBalances { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<SuperMembership> SuperMemberships { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public TaxDeclaration TaxDeclaration { get; set; }
    }
}
