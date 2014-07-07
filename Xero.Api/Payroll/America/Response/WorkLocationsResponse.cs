using System.Collections.Generic;
using Xero.Api.Common;
using Xero.Api.Payroll.America.Model;

namespace Xero.Api.Payroll.America.Response
{
    public class WorkLocationsResponse : XeroResponse<WorkLocation>
    {
        public IList<WorkLocation> WorkLocations { get; set; }

        public override IList<WorkLocation> Values
        {
            get { return WorkLocations; }
        }
    }
}