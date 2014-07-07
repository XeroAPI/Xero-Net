using System.Collections.Generic;
using Xero.Api.Common;
using Xero.Api.Core.Model.Reports;

namespace Xero.Api.Core.Response
{
    public class ReportsResponse : XeroResponse<Report>
    {
        public IList<Report> Reports { get; set; }
        
        public override IList<Report> Values
        {
            get { return Reports; }
        }
    }
}