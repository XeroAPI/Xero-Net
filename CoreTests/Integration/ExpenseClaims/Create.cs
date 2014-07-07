using System.Linq;
using NUnit.Framework;

namespace CoreTests.Integration.ExpenseClaims
{
    [TestFixture]
    public class Create : ExpenseClaimTest
    {
        [Test]
        public void create_expense_claim()
        {
            var user = Api.Users.Find().First();

            var receipt1 = Given_a_receipt(user.Id, Random.GetRandomString(10), Random.GetRandomString(30), 20m, "420");
            var receipt2 = Given_a_receipt(user.Id, Random.GetRandomString(10), Random.GetRandomString(30), 50m, "420");

            var claim = Given_an_expense_claim(user.Id, receipt1.Id, receipt2.Id);

            Assert.AreEqual(70m, claim.Total);
        }
    }
}
