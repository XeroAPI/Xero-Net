using System.Collections.Generic;
using Xero.Api.Common;
using Xero.Api.Core.Model;

namespace Xero.Api.Core.Response
{
    public class EmployeesResponse : XeroResponse<Employee>
    {
        public List<Employee> Employees { get; set; }

        public override IList<Employee> Values
        {
            get { return Employees; }
        }
    }
}