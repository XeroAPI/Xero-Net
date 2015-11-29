﻿using Xero.Api.Payroll;

namespace PayrollTests.US
{
    public class ApiWrapperTest
    {
        private AmericanPayroll _api;

        protected AmericanPayroll Api
        {
            get { return _api ?? (_api = CreateApi()); }
        }

        private static AmericanPayroll CreateApi()
        {
            return new Xero.Api.Example.Applications.Private.AmericanPayroll()
            {
                UserAgent = "Xero Api Console example (US Payroll)"
            };
        }
    }
}
