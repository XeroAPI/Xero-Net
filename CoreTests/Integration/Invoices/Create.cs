using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Types;

namespace CoreTests.Integration.Invoices
{
    [TestFixture]
    public class Create : InvoicesTest
    {
        [Test]
        public void simple_create_works()
        {
            var invoice = Given_an_invoice();

            Assert.True(invoice.Id != Guid.Empty);
        }

        [Test]
        public void description_only_items_work()
        {
            const InvoiceType expected = InvoiceType.AccountsPayable;
            var type = Given_a_description_only_invoice(expected).Type;

            Assert.AreEqual(expected, type);
        }

        [Test]
        public void accounts_receivable()
        {
            const InvoiceType expected = InvoiceType.AccountsReceivable;
            var type = Given_a_description_only_invoice(expected).Type;

            Assert.AreEqual(expected, type);
        }


        [Test]
        public void multiple_lineitems()
        {
            var invoice = Api.Create(new Invoice
            {
                Contact = new Contact { Name = "ABC Limited" },
                Type = InvoiceType.AccountsReceivable,
                Items = new List<LineItem>
                {
                    new LineItem
                    {
                        AccountCode = "200",
                        Description = "Good value item",
                        UnitAmount = 25.6m,
                        Quantity = 1m
                    },
                    new LineItem
                    {
                        AccountCode = "200",
                        Description = "Another good value item",
                        UnitAmount = 125.65m,
                        Quantity = 5m
                    }

                }
            });

            Assert.True(invoice.Id != Guid.Empty);
            Assert.AreEqual(InvoiceType.AccountsReceivable, invoice.Type);
            Assert.True(invoice.Items.Count() == 2);
        }



        [Test]
        public void multiple_invoices()
        {
            var invoices = Api.Create(new[]
            {
                new Invoice
                {
                    Contact = new Contact { Name = "ABC Limited" },
                    Type = InvoiceType.AccountsReceivable,
                    Items = new List<LineItem>
                    {
                        new LineItem
                        {
                            AccountCode = "200",
                            Description = "Good value item",
                            UnitAmount = 25.6m,
                            Quantity = 1m
                        }
                    }
                },
                new Invoice
                {
                    Contact = new Contact { Name = "Jack" },
                    Type = InvoiceType.AccountsReceivable,
                    Items = new List<LineItem>
                    {
                        new LineItem
                        {
                            AccountCode = "150",
                            Description = "Other Sales Item",
                            UnitAmount = 120.5m,
                            Quantity = 5m
                        }
                    }
                }
            }).ToList();

            Assert.AreEqual(2, invoices.Count());            
            Assert.AreEqual(2, invoices.Select(p => p.Id).Count());
        }

        [Test]
        public void high_precision_unit()
        {
            var invoices = Api.Create(new[]
            {
                new Invoice
                {
                    Contact = new Contact { Name = "ABC Limited" },
                    Type = InvoiceType.AccountsReceivable,
                    Items = new List<LineItem>
                    {
                        new LineItem
                        {
                            AccountCode = "200",
                            Description = "Good value item",
                            UnitAmount = 25.6591m,
                            Quantity = 1m
                        }
                    }
                },                
            }).ToList();

            Assert.AreEqual(25.6591m, invoices.First().Items.First().UnitAmount);
        }
    }
}