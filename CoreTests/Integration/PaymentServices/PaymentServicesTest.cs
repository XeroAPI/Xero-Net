using System;
using System.Collections.Generic;
using Xero.Api.Core;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Status;
using Xero.Api.Core.Model.Types;

namespace CoreTests.Integration.PaymentServices
{
    public abstract class PaymentServicesTest : ApiWrapperTest
    {
		private IList<PaymentService> _paymentServices;

		protected PaymentService Given_a_payment_service(string name, string url, string payNowText = "Tests Payment Service")
		{
			var fakePaymentService = CreatePaymentService(name, url, payNowText);

			fakePaymentService.Id = Guid.NewGuid();
			fakePaymentService.PaymentServiceType = "CUSTOM";

			_paymentServices.Add(fakePaymentService);
			return fakePaymentService;
        }

		protected string RandomPaymentServiceName()
		{
			return "Unit Test Payment Service " + Random.GetRandomString(10);
		}

		protected IList<PaymentService> ListPaymentServices()
		{
			return _paymentServices;
		}

		protected PaymentService CreatePaymentService(string name, string url, string payNowText = "Tests Payment Service")
		{
			var paymentService = new PaymentService
			{
				PaymentServiceName = name,
				PaymentServiceUrl = url,
				PayNowText = payNowText
			};

			return paymentService;
		}

    }
}