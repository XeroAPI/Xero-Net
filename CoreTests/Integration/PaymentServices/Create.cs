using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Xero.Api.Core.Model;

namespace CoreTests.Integration.PaymentServices
{
	[TestFixture]
	public class Create : PaymentServicesTest
	{
		[TestFixtureSetUp]
		public void CreatePaymentServicesSetUp()
		{
			SetUp();
		}

		[Test]
		public void create_payment_service()
		{

			const string url = "http://127.0.01/Xero/PayNow";
			string paymentServiceName = "Unit Test PaymentService " + Random.GetRandomString(10);

			var paymentService = Given_a_payment_service(paymentServiceName, url);

			Assert.AreEqual(paymentServiceName, paymentService.PaymentServiceName);
			Assert.AreEqual(url, paymentService.PaymentServiceUrl);

		}

	}
}
