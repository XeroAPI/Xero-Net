using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Xero.Api.Core.Model;

namespace CoreTests.Integration.Payments
{
    [TestFixture]
    public class Create : PaymentsTest
    {
        [TestFixtureSetUp]
        public void CreatePaymentsSetUp()
        {
            SetUp();
        }

        [Test]
        public void create_simple_payment()
        {
            var date = DateTime.UtcNow;
            const decimal expected = 32.6m;
            const decimal invoiceAmount = 100;

            var payment = Given_a_payment(invoiceAmount, date, expected);

            Assert.AreEqual(expected, payment.Amount);
        }

        [Test]
        public void create_multiple_payments()
        {
            var date = DateTime.UtcNow;

            var payments = Api.Create(
                new List<Payment>
                    {
                        CreatePayment(4000, date, 3375),
                        CreatePayment(393.75m, date, 393.75m),
                        CreatePayment(450, date, 398),
                    }).ToList();

            Assert.AreEqual(3, payments.Count());

            Assert.IsNotNull(payments.Single(p => p.Amount == 393.75m));
            Assert.IsNotNull(payments.Single(p => p.Amount == 3375));
            Assert.IsNotNull(payments.Single(p => p.Amount == 398));
        }

        [Test]
        public void create_reconciled_payment()
        {
            var date = DateTime.UtcNow;
            const decimal amount = 32.6m;
            const decimal invoiceAmount = 32.6m;

            var payment = Api.Create(CreatePayment(invoiceAmount, date, amount, true));

            Assert.AreEqual(amount, payment.Amount);
            Assert.True(payment.IsReconciled.HasValue);
            Assert.True(payment.IsReconciled.Value);
        }

        [Test]
        public void create_refund_on_credit_note()
        {
            const int amount = 50;
            var note = Given_an_credit_note(amount, Account.Code);
            var date = DateTime.UtcNow;
            const string reference = "Full refund as we couldn't replace item";

            var payment = Api.Create(new Payment
            {
                CreditNote = new CreditNote { Number = note.Number },
                Account = new Account { Code = BankAccount.Code },
                Date = date,
                Amount = amount,
                Reference = reference
            });

            Assert.AreEqual(reference, payment.Reference);
            Assert.AreEqual(amount, payment.Amount);
        }
    }
}
