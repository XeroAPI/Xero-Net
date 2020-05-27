using System;
using System.Linq;
using NUnit.Framework;

namespace CoreTests.Integration.PaymentServices
{
    public class Find : PaymentServicesTest
    {
        [TestFixtureSetUp]
        public void PaymentServicesSetUp()
        {
            SetUp();
        }

        [Test]
        public void find_single_payment_service()
        {
			string name = RandomPaymentServiceName();

			var created = Given_a_payment_service(name, "http://127.0.0.1/PayNow");

			var found = ListPaymentServices().FirstOrDefault();

			Assert.IsNotNull(found);

			Assert.IsNotNull(found.Id);

			Assert.AreEqual(name, found.PaymentServiceName);
			Assert.AreEqual("CUSTOM", found.PaymentServiceType);
			Assert.AreEqual(created.PaymentServiceUrl, found.PaymentServiceUrl);
		}

        [Test]
        public void find_payment_services()
        {
			Given_a_payment_service("Unit Test Payment Service 1", "http://127.0.0.1/PayNow");
			Given_a_payment_service("Unit Test Payment Service 2", "http://127.0.0.1/PayNow");

            var found = Api.PaymentServices.Find().ToList();

            Assert.IsTrue(found.Where(ps => ps.PaymentServiceName.StartsWith("Unit Test Payment Service")).Count() == 2);
        }
    }
}
