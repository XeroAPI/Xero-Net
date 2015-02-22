using System;
using NUnit.Framework;
using Xero.Api.Payroll.America.Model;
using Xero.Api.Payroll.America.Model.Types;

namespace PayrollTests.US.Integration.Employees
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
                LastName = "Smith",
                HomeAddress =
                    new HomeAddress
                    {
                        StreetAddress = "244 Jackson St",
                        SuiteOrApartmentOrUnit = "10",
                        City = "San Francisco",
                        State = State.California,
                        ZipCode = 94111,
                        Latitude = 37.79690m,
                        Longitude = -122.40033m
                    },
                DateOfBirth = new DateTime(1984, 02, 05)
            });

            Assert.IsTrue(Guid.Empty != emp.Id);
            Assert.AreEqual("John", emp.FirstName);
        }

        [Test]
        public void create_employee_with_opening_balances()
        {
            Assert.DoesNotThrow(() =>
            {
                var employee = Api.Create(new Employee
                {
                    FirstName = "John",
                    LastName = "Smith",
                    //OpeningBalances = new OpeningBalances
                    // {
                    //EarningsLines = new List<EarningsLine>
                    //{
                    //    new EarningsLine
                    //    {
                    //        EarningsTypeId = earnings_type_id(),
                    //        Amount = 200m,
                    //    }
                    //},
                    //DeductionLines = new List<DeductionLine>
                    //{
                    //    new DeductionLine
                    //   {
                    //        DeductionTypeId = deduction_type_id(),
                    //        Amount = 10m,
                    //    }
                    //},
                    //ReimbursementLines = new List<ReimbursementLine>
                    //{
                    //    new ReimbursementLine
                    //    {
                    //        Id = reimbersment_type_id(),
                    //        Amount = 12.50m
                    //    }
                    //}
                    //LeaveLines = new List<LeaveLine>
                    //{
                    //    new LeaveLine
                    //    {
                    //        LeaveTypeId = leave_type_id(),
                    //        NumberOfUnits = 2
                    //    }
                    //},
                    // }
                });
            });


            //[Test]
            //public void create_employee_with_taxdeclarations()
            //{
            //    Assert.DoesNotThrow(() =>
            //    {
            //        var emp = Api.Add(new Employee
            //        {
            //            FirstName = "John",
            //            MiddleNames = "James",
            //            LastName = "Smith",
            //            TaxDeclaration = new TaxDeclaration
            //            {
            //                TaxFileNumberPendingOrExemptionHeld = false,
            //                AustralianResidentForTaxPurposes = true,
            //                TaxFreeThresholdClaimed = true,
            //                HasHigherEducationLoanProgramDebt = false,
            //                HasStudentFinancialSupplementSchemeDebt = false,
            //                EligibleToReceiveLeaveLoading = false
            //            }

            //        });

            //        Assert.IsTrue(Guid.Empty != emp.Id);
            //    });
            //}

        }
    }
}
