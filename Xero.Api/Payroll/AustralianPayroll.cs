using System.Collections.Generic;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Payroll.Australia.Endpoints;
using Xero.Api.Payroll.Australia.Model;
using Xero.Api.Payroll.Common;
using Xero.Api.Payroll.Common.Endpoints;
using Xero.Api.Payroll.Common.Model;
using PayRun = Xero.Api.Payroll.Australia.Model.PayRun;

namespace Xero.Api.Payroll
{
    public class AustralianPayroll : PayrollApi
    {
        public AustralianPayroll(string baseUri, IAuthenticator auth, IConsumer consumer, IUser user, IJsonObjectMapper readMapper, IXmlObjectMapper writeMapper)
            : base(baseUri, auth, consumer, user, readMapper, writeMapper)
        {
            Connect();
        }

        public AustralianPayroll(string baseUri, ICertificateAuthenticator auth, IConsumer consumer, IUser user, IJsonObjectMapper readMapper, IXmlObjectMapper writeMapper)
            : base(baseUri, auth, consumer, user, readMapper, writeMapper)
        {
            Connect();
        }

        public SuperFundsEndpoint SuperFunds { get; set; }
        public SuperFundProductsEndpoint SuperFundProducts { get; set; }
        public LeaveApplicationsEndpoint LeaveApplications { get; set; }
        public PayslipsEndpoint Payslips { get; private set; }

        public EmployeesEndpoint Employees { get; private set; }
        public PayRunsEndpoint PayRuns { get; private set; }
        public TimesheetsEndpoint Timesheets { get; private set; }

        public PayItemsEndpoint PayItems { get; private set; }
        public PayrollCalendarsEndpoint PayrollCalendars { get; private set; }
        public SettingsEndpoint Settings { get; private set; }

        private void Connect()
        {
            LeaveApplications = new LeaveApplicationsEndpoint(Client);
            SuperFundProducts = new SuperFundProductsEndpoint(Client);
            SuperFunds = new SuperFundsEndpoint(Client);
            Payslips = new PayslipsEndpoint(Client);

            Employees = new EmployeesEndpoint(Client);
            PayRuns = new PayRunsEndpoint(Client);
            Timesheets = new TimesheetsEndpoint(Client);
            PayItems = new PayItemsEndpoint(Client);
            PayrollCalendars = new PayrollCalendarsEndpoint(Client);
            Settings = new SettingsEndpoint(Client);
        }

        public IEnumerable<LeaveApplication> Create(IEnumerable<LeaveApplication> items)
        {
            return LeaveApplications.Create(items);
        }

        public IEnumerable<Payslip> Create(IEnumerable<Payslip> items)
        {
            return Payslips.Create(items);
        }

        public IEnumerable<SuperFund> Create(IEnumerable<SuperFund> items)
        {
            return SuperFunds.Create(items);
        }

        public IEnumerable<Employee> Create(IEnumerable<Employee> items)
        {
            return Employees.Create(items);
        }

        public IEnumerable<PayRun> Create(IEnumerable<PayRun> items)
        {
            return PayRuns.Create(items);
        }

        public IEnumerable<Timesheet> Create(IEnumerable<Timesheet> items)
        {
            return Timesheets.Create(items);
        }

        public IEnumerable<PayrollCalendar> Create(IEnumerable<PayrollCalendar> items)
        {
            return PayrollCalendars.Create(items);
        }

        public LeaveApplication Create(LeaveApplication item)
        {
            return LeaveApplications.Create(item);
        }

        public Payslip Create(Payslip item)
        {
            return Payslips.Create(item);
        }

        public SuperFund Create(SuperFund item)
        {
            return SuperFunds.Create(item);
        }

        public Employee Create(Employee item)
        {
            return Employees.Create(item);
        }

        public PayRun Create(PayRun item)
        {
            return PayRuns.Create(item);
        }

        public Timesheet Create(Timesheet item)
        {
            return Timesheets.Create(item);
        }

        public PayItems Create(PayItems item)
        {
            return PayItems.Create(item);
        }

        public PayrollCalendar Create(PayrollCalendar item)
        {
            return PayrollCalendars.Create(item);
        }

        public IEnumerable<LeaveApplication> Update(IEnumerable<LeaveApplication> items)
        {
            return LeaveApplications.Update(items);
        }

        public IEnumerable<Payslip> Update(IEnumerable<Payslip> items)
        {
            return Payslips.Update(items);
        }

        public IEnumerable<SuperFund> Update(IEnumerable<SuperFund> items)
        {
            return SuperFunds.Update(items);
        }

        public IEnumerable<Employee> Update(IEnumerable<Employee> items)
        {
            return Employees.Update(items);
        }

        public IEnumerable<PayRun> Update(IEnumerable<PayRun> items)
        {
            return PayRuns.Update(items);
        }

        public IEnumerable<Timesheet> Update(IEnumerable<Timesheet> items)
        {
            return Timesheets.Update(items);
        }

        public IEnumerable<PayrollCalendar> Update(IEnumerable<PayrollCalendar> items)
        {
            return PayrollCalendars.Update(items);
        }

        public LeaveApplication Update(LeaveApplication item)
        {
            return LeaveApplications.Update(item);
        }

        public Payslip Update(Payslip item)
        {
            return Payslips.Update(item);
        }

        public SuperFund Update(SuperFund item)
        {
            return SuperFunds.Update(item);
        }

        public Employee Update(Employee item)
        {
            return Employees.Update(item);
        }

        public PayRun Update(PayRun item)
        {
            return PayRuns.Update(item);
        }

        public Timesheet Update(Timesheet item)
        {
            return Timesheets.Update(item);
        }

        public PayItems Update(PayItems item)
        {
            return PayItems.Update(item);
        }

        public PayrollCalendar Update(PayrollCalendar item)
        {
            return PayrollCalendars.Update(item);
        }
    }
}