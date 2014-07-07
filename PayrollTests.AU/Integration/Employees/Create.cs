using System;
using System.Collections.Generic;
using NUnit.Framework;
using Xero.Api.Payroll.Australia.Model;

namespace PayrollTests.AU.Integration.Employees
{
    [TestFixture]
    public class Create : EmployeesTest
    {
        [Test]
        public void create_employee()
        {
            var emp = Api.Create(new Employee
            {
                FirstName = "John",
                MiddleNames = "James",
                LastName = "Smith",
                Title = "Mr",
                DateOfBirth = new DateTime(1984, 02, 05),
                Gender = "M",
                Email = "jjs@gmail.com",
                Mobile = "9242422342",
                TwitterUserName = "@jjs",
                StartDate = new DateTime(2007, 06, 13),
                BankAccounts =
                    new List<BankAccount>
                    {
                        new BankAccount
                        {
                            AccountName = "Cheque",
                            AccountNumber = "645645645",
                            BankStateBranch = 121232,
                            Remainder = true,
                            StatementText = "Salary"
                        }
                    },
                Classification = "Management",
                HomeAddress =
                    new HomeAddress
                    {
                        AddressLine1 = "12 Main Street",
                        City = "Perth",
                        Country = "Australia",
                        PostalCode = 6001
                    }
            });

            Assert.IsTrue(Guid.Empty != emp.Id);
            Assert.AreEqual("John", emp.FirstName);
        }

        [Test]
        public void create_employee_with_taxdeclarations()
        {
            var emp = Api.Create(new Employee
            {
                FirstName = "John",
                MiddleNames = "James",
                LastName = "Smith",
                TaxDeclaration = new TaxDeclaration
                {
                    TaxFileNumberPendingOrExemptionHeld = false,
                    AustralianResidentForTaxPurposes = true,
                    TaxFreeThresholdClaimed = true,
                    HasHigherEducationLoanProgramDebt = false,
                    HasStudentFinancialSupplementSchemeDebt = false,
                    EligibleToReceiveLeaveLoading = false
                }

            });

            Assert.IsTrue(Guid.Empty != emp.Id);
        }

        [Test]
        public void create_employee_with_opening_balances()
        {
            Assert.DoesNotThrow(() => Api.Create(new Employee
            {
                FirstName = "John",
                MiddleNames = "James",
                LastName = "Smith",
                OpeningBalances = new OpeningBalances
                {
                    OpeningBalanceDate = new DateTime(2013, 04, 23),
                    EarningsLines = new List<EarningsLine>
                    {
                        new EarningsLine
                        {
                            EarningsRateId = earnings_rate_id(),
                            Amount = 200m,
                        }
                    },
                    DeductionLines = new List<DeductionLine>
                    {
                        new DeductionLine
                        {
                            DeductionTypeId = deduction_type_id(),
                            Amount = 10m,
                        }
                    },
                    ReimbursementLines = new List<ReimbursementLine>
                    {
                        new ReimbursementLine
                        {
                            Id = reimbersment_type_id(),
                            Amount = 12.50m
                        }
                    },
                    LeaveLines = new List<LeaveLine>
                    {
                        new LeaveLine
                        {
                            LeaveTypeId = leave_type_id(),
                            NumberOfUnits = 2
                        }
                    },
                }
            }));
        }
    }
}
