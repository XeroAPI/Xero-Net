﻿using Xero.Api.Payroll;

namespace PayrollTests.AU
{
    public class ApiWrapperTest
    {
        private AustralianPayroll _api;

        protected AustralianPayroll Api
        {
            get { return _api ?? (_api = CreateApi()); }
        }

        private static AustralianPayroll CreateApi()
        {
            return new Xero.Api.Example.Applications.Private.AustralianPayroll()
            {
                UserAgent = "Xero Api Console example (AU Payroll)"
            };
        }
    }
}
