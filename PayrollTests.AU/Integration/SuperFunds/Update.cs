﻿using System;
using NUnit.Framework;
using Xero.Api.Payroll.Australia.Model;
using Xero.Api.Payroll.Australia.Model.Types;

namespace PayrollTests.AU.Integration.SuperFunds
{
    [TestFixture]
    public class Update : ApiWrapperTest
    {
        [Test]
        public void update_superfund()
        {
            var sf = Api.Create(new SuperFund
            {
                Type = SuperfundType.SelfManaged,
                Abn = 11001032511,
                Name = "Clive Monk Superannuation Fund",
                BankStateBranch = 159357,
                AccountName = "Clive Monk Superannuation Fund",
                AccountNumber = 111222333,
            });


            var updated_superfund = Api.Update(new SuperFund
            {
                Id = sf.Id,
                Type = SuperfundType.SelfManaged,
                Abn = 11001032511,
                Name = "Clive Superannuation Fund",
                BankStateBranch = 159357,
                AccountName = "Test",
                AccountNumber = 654645645,
            });

        }
    }
}
