using System.Runtime.Serialization;
using Xero.Api.Common;
using Xero.Api.Payroll.Common.Model;

namespace Xero.Api.Payroll.Common.Request
{
    [CollectionDataContract(Namespace = "", Name = "Timesheets")]
    public class TimesheetsRequest : XeroRequest<Timesheet>
    {
    }
}