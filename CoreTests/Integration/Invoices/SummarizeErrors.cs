using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Status;
using Xero.Api.Core.Model.Types;
using Xero.Api.Infrastructure.Exceptions;

namespace CoreTests.Integration.Invoices
{
    [TestFixture]
    public class SummarizeErrors : InvoicesTest
    {
        [Test]
        public void summariseErrors_gives_200()
        {
            var invoices = Given_a_bad_invoice(summariseErrors: false);

            Assert.True(invoices.Count(p => p.ValidationStatus == ValidationStatus.Error) == 1);
            Assert.True(invoices.Count(p => p.ValidationStatus == ValidationStatus.Ok) == 1);
        }

        [Test] public void errors_gives_validation_exception()
        {
            Assert.Throws<ValidationException>(() => Given_a_bad_invoice());
        }

        private IEnumerable<Invoice> Given_a_bad_invoice(InvoiceType type = InvoiceType.AccountsPayable, InvoiceStatus status = InvoiceStatus.Draft, bool summariseErrors = true)
        {
            Api.Invoices.SummarizeErrors(summariseErrors);
            return Api.Create(new[]
            {
                new Invoice
                {
                    Contact = new Contact {Name = "ABC Bank"},
                    Type = type,
                    Date = DateTime.UtcNow,
                    DueDate = DateTime.UtcNow.AddDays(90),
                    LineAmountTypes = LineAmountType.Inclusive,
                    Status = status,
                    Items = new List<LineItem>
                    {
                        new LineItem
                        {
                            AccountCode = "200",
                            Description = "Good value item",
                            LineAmount = 100m
                        }
                    }
                },
                new Invoice
                {
                    Contact = new Contact
                    {
                        Name = "ABC Bank",
                        EmailAddress = "this_is_!_valid"
                    },
                    Type = type,
                    Date = DateTime.UtcNow,
                    DueDate = DateTime.UtcNow.AddDays(90),
                    LineAmountTypes = LineAmountType.Inclusive,
                    Status = status,
                    Items = new List<LineItem>
                    {
                        new LineItem
                        {
                            AccountCode = "200",
                            Description = "Good value item",
                            LineAmount = 100m
                        }
                    }
                }
            });
        }
    }
}
