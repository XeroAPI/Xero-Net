using System.Linq;
using Xero.Api.Core;
using Xero.Api.Core.Model;

namespace CoreTests
{
    public class ApiWrapperTest
    {
        public ApiWrapperTest()
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
        }

        private IXeroCoreApi _api;

        protected Account BankAccount { get; set; }
        protected Account Account { get; set; }
        
        protected IXeroCoreApi Api
        {
            get { return _api ?? (_api = CreateCoreApi()); }
        }

        private static IXeroCoreApi CreateCoreApi()
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
