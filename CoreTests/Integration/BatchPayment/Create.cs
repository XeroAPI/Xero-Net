using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Xero.Api.Core.Model;

namespace CoreTests.Integration.BatchPayments
{
    [TestFixture]
    public class Create : BatchPaymentsTest
    {
        [TestFixtureSetUp]
        public void CreateBatchPaymentsSetUp()
        {
            SetUp();
        }

        [Test]
        public void create_simple_batch_payment()
        {
            var date = DateTime.UtcNow;
            const decimal expectedTotal = 32.6m;
            const decimal invoiceAmount = 100;

			var batchPayment = Given_a_batch_payment(invoiceAmount, date, expectedTotal);

			Assert.IsNotNull(batchPayment);

			Assert.AreEqual(expectedTotal, batchPayment.Total);
			Assert.AreEqual(date.Date, batchPayment.Date);


		}

    }
}
