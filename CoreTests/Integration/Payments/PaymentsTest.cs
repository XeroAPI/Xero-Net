using System;
using System.Collections.Generic;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Status;
using Xero.Api.Core.Model.Types;

namespace CoreTests.Integration.Payments
{
    public abstract class PaymentsTest : ApiWrapperTest
    {
        protected Payment Given_a_payment(decimal invoiceAmount, DateTime date, decimal amount, bool isReconciled = false)
        {
            return Api.Create(CreatePayment(invoiceAmount, date, amount, isReconciled));
        }

        protected Payment CreatePayment(decimal invoiceAmount, DateTime date, decimal amount, bool isReconciled = false)
        {
            var invoice = Given_an_invoice(invoiceAmount, Account.Code);
            var bankCode = BankAccount.Code;

            var payment = new Payment
            {
                Invoice = new Invoice { Number = invoice.Number },
                Account = new Account { Code = bankCode },
                Date = date,
                Amount = amount
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

        protected CreditNote Given_an_credit_note(decimal amount = 100m, string accountCode = "100")
        {
            return Api.Create(new CreditNote
            {
                Contact = new Contact { Name = "Richard" },
                Number = Random.GetRandomString(10),
                Type = CreditNoteType.AccountsPayable,
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