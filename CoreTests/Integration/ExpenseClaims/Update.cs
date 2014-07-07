using System.Linq;
using NUnit.Framework;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Status;

namespace CoreTests.Integration.ExpenseClaims
{
    [TestFixture]
    public class Update : ExpenseClaimTest
    {
        [Test]
        public void authorise_expense_claim()
        {
            var user = Api.Users.Find().First();

            var receipt1 = Given_a_receipt(user.Id, Random.GetRandomString(10), Random.GetRandomString(30), 20m, "420");
            var receipt2 = Given_a_receipt(user.Id, Random.GetRandomString(10), Random.GetRandomString(30), 50m, "420");

            var claim = Given_an_expense_claim(user.Id, receipt1.Id, receipt2.Id);

            var authorised = Api.Update(
                new ExpenseClaim
                {
                    Id = claim.Id,
                    Status = ExpenseClaimStatus.Authorised
                });

            Assert.AreEqual(ExpenseClaimStatus.Authorised, authorised.Status);
        }

        [Test]
        public void void_expense_claim()
        {
            var user = Api.Users.Find().First();

            var receipt1 = Given_a_receipt(user.Id, Random.GetRandomString(10), Random.GetRandomString(30), 20m, "420");
            var receipt2 = Given_a_receipt(user.Id, Random.GetRandomString(10), Random.GetRandomString(30), 50m, "420");

            var claim = Given_an_expense_claim(user.Id, receipt1.Id, receipt2.Id);

            var authorised = Api.Update(
                new ExpenseClaim
                {
                    Id = claim.Id,
                    Status = ExpenseClaimStatus.Authorised
                });

            var voided = Api.Update(
                new ExpenseClaim
                {
                    Id = authorised.Id,
                    Status = ExpenseClaimStatus.Voided
                });

            Assert.AreEqual(ExpenseClaimStatus.Voided, voided.Status);
        }
    }
}