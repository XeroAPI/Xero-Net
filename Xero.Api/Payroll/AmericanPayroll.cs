using System.Collections.Generic;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.RateLimiter;
using Xero.Api.Payroll.America.Endpoints;
using Xero.Api.Payroll.America.Model;
using Xero.Api.Payroll.Common;
using PayRun = Xero.Api.Payroll.America.Model.PayRun;

namespace Xero.Api.Payroll
{
    public class AmericanPayroll : PayrollApi
    {
        public AmericanPayroll(string baseUri, IAuthenticator auth, IConsumer consumer, IUser user,
            IJsonObjectMapper readMapper, IXmlObjectMapper writeMapper)
            : this(baseUri, auth, consumer, user, readMapper, writeMapper, null)
        {
        }

        public AmericanPayroll(string baseUri, IAuthenticator auth, IConsumer consumer, IUser user, IJsonObjectMapper readMapper, IXmlObjectMapper writeMapper, IRateLimiter rateLimiter)
            : base(baseUri, auth, consumer, user, readMapper, writeMapper, rateLimiter)
        {
            Connect();
        }

        public WorkLocationsEndpoint WorkLocations { get; private set; }
        public PayStubsEndpoint PayStubs { get; private set; }
        public PayItemsEndpoint PayItems { get; private set; }
        public PaySchedulesEndpoint PaySchedules { get; private set; }
        public EmployeesEndpoint Employees { get; private set; }
        public PayRunsEndpoint PayRuns { get; private set; }
        public TimesheetsEndpoint Timesheets { get; private set; }
        public SettingsEndpoint Settings { get; private set; }

        private void Connect()
        {
            WorkLocations = new WorkLocationsEndpoint(Client);
            PayStubs = new PayStubsEndpoint(Client);
            PayItems = new PayItemsEndpoint(Client);
            PaySchedules = new PaySchedulesEndpoint(Client);
            Employees = new EmployeesEndpoint(Client);
            PayRuns = new PayRunsEndpoint(Client);
            Settings = new SettingsEndpoint(Client);
            Timesheets = new TimesheetsEndpoint(Client);            
        }

        public IEnumerable<PaySchedule> Create(IEnumerable<PaySchedule> items)
        {
            return PaySchedules.Create(items);
        }

        public IEnumerable<WorkLocation> Create(IEnumerable<WorkLocation> items)
        {
            return WorkLocations.Create(items);
        }

        public IEnumerable<PayStub> Create(IEnumerable<PayStub> items)
        {
            return PayStubs.Create(items);
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

        public PaySchedule Create(PaySchedule item)
        {
            return PaySchedules.Create(item);
        }

        public WorkLocation Create(WorkLocation item)
        {
            return WorkLocations.Create(item);
        }

        public PayStub Create(PayStub item)
        {
            return PayStubs.Create(item);
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

        public IEnumerable<PaySchedule> Update(IEnumerable<PaySchedule> items)
        {
            return PaySchedules.Update(items);
        }

        public IEnumerable<WorkLocation> Update(IEnumerable<WorkLocation> items)
        {
            return WorkLocations.Update(items);
        }

        public IEnumerable<PayStub> Update(IEnumerable<PayStub> items)
        {
            return PayStubs.Update(items);
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

        public PaySchedule Update(PaySchedule item)
        {
            return PaySchedules.Update(item);
        }

        public WorkLocation Update(WorkLocation item)
        {
            return WorkLocations.Update(item);
        }

        public PayStub Update(PayStub item)
        {
            return PayStubs.Update(item);
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
    }
}