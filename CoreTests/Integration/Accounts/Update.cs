using System;
using NUnit.Framework;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Status;
using Xero.Api.Core.Model.Types;

namespace CoreTests.Integration.Accounts
{
    public class Update : ApiWrapperTest
    {
        [Test]
        public void Update_account()
        {
            var expectedDescription = "Updated Account" + Guid.NewGuid();

            var account = CreateAccount();

            account.Description = expectedDescription;

            Api.Accounts.Update(account);

            var updated = Api.Accounts.Find(account.Id);

            Assert.True(updated.Description == expectedDescription);
        }


        [Test]
        public void Archive_account()
        {
            var account = CreateAccount();

            Api.Accounts.Update(new Account
            {
                Id = account.Id,
                Status = AccountStatus.Archived
            });

            var updated = Api.Accounts.Find(account.Id);

            Assert.True(updated.Status == AccountStatus.Archived);
        }

        private Account CreateAccount()
        {
            var code = "1234" + Guid.NewGuid();

            return Api.Accounts.Create(new Account
            {
                Code = code.Substring(0, 10),
                Name = "New Account " + Guid.NewGuid(),
                Type = AccountType.Sales
            });
        }

    }
}
