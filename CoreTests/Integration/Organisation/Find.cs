using System;
using NUnit.Framework;
using Xero.Api.Core.Model.Types;

namespace CoreTests.Integration.Organisation
{
    [TestFixture]
    public class Find : ApiWrapperTest
    {
        [Test]
        public void can_get_the_organisation_sales_tax_basis()
        {
            var test = Api.Organisation.SalesTaxBasisType;

            Assert.True(Enum.IsDefined(typeof(SalesTaxBasisType), test));
        }

        [Test]
        public void can_get_the_organisation_sales_tax_period()
        {
            var test = Api.Organisation.SalesTaxPeriod;

            Assert.True(Enum.IsDefined(typeof(SalesTaxPeriodType), test));
        }
    }
}
