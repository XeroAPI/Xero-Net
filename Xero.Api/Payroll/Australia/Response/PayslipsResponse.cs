using System.Collections.Generic;
using System.Runtime.Serialization;
using Xero.Api.Common;
using Xero.Api.Payroll.Australia.Model;

namespace Xero.Api.Payroll.Australia.Response
{
    public class PayslipsResponse : XeroResponse<Payslip>
    {
        public IList<Payslip> Payslips { get; set; }

        public override IList<Payslip> Values
        {
            get { return Payslips; }
        }
    }
}