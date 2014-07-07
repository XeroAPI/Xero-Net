using System.Linq;
using Xero.Api.Core;
using Xero.Api.Core.Model;

namespace CoreTests
{
    public class ApiWrapperTest
    {
        private XeroCoreApi _api;

        protected Account BankAccount { get; set; }
        protected Account Account { get; set; }
        
        protected XeroCoreApi Api
        {
            get { return _api ?? (_api = CreateCoreApi()); }
        }

        private static XeroCoreApi CreateCoreApi()
        {
            return new Xero.Api.Example.Applications.Private.Core
            {
                UserAgent = "Xero Api - Integration tests"
            };
        }

        protected void SetUp()
        {
            BankAccount = Given_a_bank_account();
            Account = Given_an_account();
        }

        protected Account Given_a_bank_account()
        {
            return Api.Accounts.Where("Type == \"BANK\"").Find().First();
        }

        protected Account Given_an_account()
        {
            return Api.Accounts.Where("Type != \"BANK\"").Find().First();
        }
    }
}
