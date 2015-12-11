using System.Linq;
using NUnit.Framework;
using Xero.Api.Core.Model.Types;

namespace CoreTests.Integration.Prepayments
{
    [TestFixture]
    public class Find : ApiWrapperTest
    {
        [Test]
        public void find_all()
        {
            var prepayments = Api.Prepayments.Find();
            Assert.Greater(prepayments.Count(), 0);
        }

        [Test]
        public void find_all_receive_prepayments()
        {
            var prepayments = Api.Prepayments.Where("Type == \"RECEIVE-PREPAYMENT\"").Find();
            Assert.True(prepayments.All(p => p.Type == PrepaymentType.ReceivePrepayment));
        }

        [Test]
        public void find_all_spend_prepayments()
        {
            var prepayments = Api.Prepayments.Where("Type == \"SPEND-PREPAYMENT\"").Find();
            Assert.True(prepayments.All(p => p.Type == PrepaymentType.SpendPrepayment));
        }
    }
}
