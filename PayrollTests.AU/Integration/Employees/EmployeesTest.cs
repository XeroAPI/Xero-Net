using System;
using System.Linq;
using Xero.Api.Payroll.Australia.Model;
using Xero.Api.Payroll.Australia.Model.Types;

namespace PayrollTests.AU.Integration.Employees
{
    public abstract class EmployeesTest : ApiWrapperTest
    {
        protected Employee Given_an_employee(bool terminated = false)
        {
            var employee = Api.Create(new Employee
            {
                FirstName = "John " + Guid.NewGuid().ToString("N"),
                LastName = "Smith",
                TerminationDate = terminated ? (DateTime?)DateTime.Now.Date : null
            });

            return employee;
        }

        protected Employee given_terminated_employee()
        {
            return Given_an_employee(true);
        }

        protected Guid earnings_rate_id()
        {
            return Api.PayItems.Find().FirstOrDefault().EarningsRates.FirstOrDefault().Id;
        }


        protected Guid deduction_type_id()
        {
            return Api.PayItems.Find().FirstOrDefault().DeductionTypes.FirstOrDefault().Id;
        }

        protected Guid reimbersment_type_id()
        {
            return Api.PayItems.Find().FirstOrDefault().ReimbursementTypes.FirstOrDefault().Id;
        }


        protected Guid leave_type_id()
        {
            return Api.PayItems.Find().FirstOrDefault().LeaveTypes.FirstOrDefault().Id;
        }


        protected Guid super_fund_id()
        {
            var sf = Api.SuperFunds.Find();
            
            if (sf.FirstOrDefault().Id != Guid.Empty)
            {
                return sf.FirstOrDefault().Id;
            }
            else
            {
                return Api.Create(new SuperFund
                {
                    Type = SuperfundType.Regulated,
                    Abn = "78984178687",
                }).Id;
            }
        }

    }
}
