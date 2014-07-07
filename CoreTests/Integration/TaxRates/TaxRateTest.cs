using System.Collections.Generic;
using System.Linq;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Types;

namespace CoreTests.Integration.TaxRates
{
    public abstract class TaxRateTest : ApiWrapperTest
    {
        protected TaxRate Given_a_tax_rate(string name, ReportTaxType taxType, string state, decimal stateRate, string local, decimal localRate)
        {
            return Api.Create(new[]{ new TaxRate
            {
                Name = name,
                ReportTaxType = taxType,
                TaxComponents = new List<TaxComponent>
                {
                    new TaxComponent
                    {
                        Name = state,
                        Rate = stateRate
                    },
                    new TaxComponent
                    {
                        Name = local,
                        Rate = localRate
                    }
                }
            }}).First();
        }
    }
}
