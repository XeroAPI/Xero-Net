﻿using System.Linq;
using NUnit.Framework;
using Xero.Api.Core.Model.Status;
using Xero.Api.Core.Model.Types;

namespace CoreTests.Integration.TaxRates
{
    [TestFixture]
    public class Update : TaxRateTest
    {
        [Test]
        public void update_tax_rate()
        {
            var name = Random.GetRandomString(10);
            var state = Random.GetRandomString(5);
            var local = Random.GetRandomString(5);

            const decimal stateRate = 7.5m;
            const decimal localRate = 0.625m;
            const ReportTaxType taxType = ReportTaxType.Input;

            var taxRate = Given_a_tax_rate(name, taxType, state, stateRate, local, localRate);

            // the local tax rate is increased                
            const decimal expected = 0.7m;

            var component = taxRate.TaxComponents.Single(p => p.Name == local);
            component.Rate = expected;
            var updated = Api.Update(taxRate);

            Assert.AreEqual(expected, updated.TaxComponents.Single(p => p.Name == local).Rate);
        }

        [Test]
        public void delete_tax_rate()
        {
            var name = Random.GetRandomString(10);
            var state = Random.GetRandomString(5);
            var local = Random.GetRandomString(5);

            const decimal stateRate = 7.5m;
            const decimal localRate = 0.625m;
            const TaxRateStatus expected = TaxRateStatus.Deleted;

            var taxRate = Given_a_tax_rate(name, ReportTaxType.Input, state, stateRate, local, localRate);
            taxRate.Status = expected;
            var updated = Api.TaxRates.Update(taxRate);

            Assert.That(expected == updated.Status);
        }
    }
}
