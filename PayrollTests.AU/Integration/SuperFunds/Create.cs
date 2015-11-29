﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Xero.Api.Payroll.Australia.Model;
using Xero.Api.Payroll.Australia.Model.Types;

namespace PayrollTests.AU.Integration.SuperFunds
{
    [TestFixture]
    public class Create : ApiWrapperTest
    {
        [Test]
        public void create_superfund()
        {
            var sf = Api.Create(new SuperFund
            {
                Type = SuperfundType.Regulated,
                Abn = 78984178687,
            });

            Assert.IsTrue(sf.Id != Guid.Empty);
        }
    }
}
