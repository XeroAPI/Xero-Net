using System.Runtime.Serialization;
using Xero.Api.Common;
using Xero.Api.Payroll.Australia.Model;

namespace Xero.Api.Payroll.Australia.Request
{
    [CollectionDataContract(Namespace = "", Name = "Payslips")]
    public class PayslipRequest : XeroRequest<Payslip>
    {
    }
}