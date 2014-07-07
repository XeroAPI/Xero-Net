using System.Collections.Generic;
using Xero.Api.Common;
using Xero.Api.Payroll.Australia.Model;

namespace Xero.Api.Payroll.Australia.Response
{
    public class LeaveApplicationsResponse : XeroResponse<LeaveApplication>
    {
        public IList<LeaveApplication> LeaveApplications { get; set; }

        public override IList<LeaveApplication> Values
        {
            get { return LeaveApplications; }
        }
    }
}