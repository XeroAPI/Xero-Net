using System;
using System.Linq;
using NUnit.Framework;
using Xero.Api.Core.Model.Types;

namespace CoreTests.Integration.Invoices
{
    [TestFixture]
    public class Find : InvoicesTest
    {
        [Test]
        public void find_by_page()
        {
            Given_an_invoice();
            var invoices = Api.Invoices.Page(1).Find();
            
            Assert.Greater(invoices.Count(), 0);
        }

        [Test]
        public void find_by_id()
        {
            var expected  = Given_an_invoice().Id;
            var id = Api.Invoices.Find(expected).Id;

            Assert.AreEqual(expected, id);
        }

        [Test]
        public void find_by_value()
        {
            Given_an_invoice();
            var invoices = Api.Invoices
                .Where("Type == \"ACCREC\"")
                .Find()
                .ToList();

            Assert.True(invoices.Any());
            Assert.True(invoices.All(p => p.Type == InvoiceType.AccountsReceivable));            
        }

        [Test]
        public void find_by_due_date()
        {
            Given_an_invoice();

            var today = DateTime.UtcNow;

            var invoices = Api.Invoices
                .Where(string.Format("DueDate > DateTime({0},{1},{2})", today.Year, today.Month, today.Day ))
                .Find()
                .ToList();

            Assert.True(invoices.Any());           
        }

        [Test]
        public void order_by_type()
        {
            var invoices = Api.Invoices.OrderByDescending("Type").Find();

            Assert.AreEqual(InvoiceType.AccountsReceivable, invoices.First().Type);
        }
    }
}
