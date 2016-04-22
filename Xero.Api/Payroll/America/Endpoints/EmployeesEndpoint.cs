using Xero.Api.Infrastructure.Http;
using Xero.Api.Payroll.America.Response;
using Xero.Api.Payroll.Common;
using Employee = Xero.Api.Payroll.America.Model.Employee;
using EmployeesRequest = Xero.Api.Payroll.America.Request.EmployeesRequest;

namespace Xero.Api.Payroll.America.Endpoints
{
    public class EmployeesEndpoint : PayrollEndpoint<EmployeesEndpoint, Employee, EmployeesRequest, EmployeesResponse>
    {
        public EmployeesEndpoint(XeroHttpClientPayroll client)
            : base(client, "/Employees")
        {
        }
    }
}
