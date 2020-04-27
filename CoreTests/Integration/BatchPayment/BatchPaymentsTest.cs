using System;
using System.Collections.Generic;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Status;
using Xero.Api.Core.Model.Types;

namespace CoreTests.Integration.BatchPayments
{
    public abstract class BatchPaymentsTest : ApiWrapperTest
    {
        protected BatchPayment Given_a_batch_payment(decimal invoiceAmount, DateTime date, decimal amount, bool isReconciled = false)
        {
			var batchPayment = CreateBatchPayment(invoiceAmount, date, amount, isReconciled);

			return Api.BatchPayments.Create(batchPayment);
        }

        protected BatchPayment CreateBatchPayment(decimal invoiceAmount, DateTime date, decimal amount, bool isReconciled = false)
        {
            var invoice = Given_an_invoice(invoiceAmount, Account.Code);
            var bankCode = BankAccount.Id;

            var payment = new BatchPayment
			{
				Account = new Account { Id = bankCode },
				Date = date,
				Payments = new List<BatchPaymentPayment> { new BatchPaymentPayment {
					Amount = amount,
					Invoice = new Invoice { Id = invoice.Id},
					BankAccountNumber = BankAccount.BankAccountNumber,
				}}
            };

            if (isReconciled)
            {
                payment.IsReconciled = true;
            }

            return payment;
        }

		private Invoice Given_an_invoice(decimal amount = 100m, string accountCode = "100")
		{
			return Api.Create(new Invoice
			{
				Contact = new Contact { Name = "Richard" },
				Number = Random.GetRandomString(10),
				Type = InvoiceType.AccountsPayable,
				Date = DateTime.UtcNow,
				DueDate = DateTime.UtcNow.AddDays(90),
				LineAmountTypes = LineAmountType.Inclusive,
				Status = InvoiceStatus.Authorised,
				LineItems = new List<LineItem>
				{
					new LineItem
					{
						AccountCode = accountCode,
						Description = "Good value item",
						LineAmount = amount
					}
				}
			});
		}

    }
}