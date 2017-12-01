﻿using System;
using System.Collections;
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
        [TestCase(true, "unitdp=4&page=1")]
        [TestCase(false, "page=1")]
        public void find_by_page_reset_query(bool resetQuery, string expectedQuery)
        {
            Given_an_invoice();

            var api = Api.Invoices.UseFourDecimalPlaces(false).Page(1);
            
            Assert.True(api.Find(resetQuery: resetQuery).Any());
            Assert.That(api.QueryString, Is.EqualTo(expectedQuery));
        }

        [Test]
        public void find_by_id()
        {
            var expected  = Given_an_invoice().Id;
            var id = Api.Invoices.Find(expected).Id;

            Assert.AreEqual(expected, id);
        }

        [Test]
        [TestCase(true, "unitdp=4&page=1")]
        [TestCase(false, "page=1")]
        public void find_by_id_reset_query(bool resetQuery, string expectedQuery)
        {
            var expected  = Given_an_invoice().Id;
            
            var api = Api.Invoices.UseFourDecimalPlaces(false);
                
            api.Find(expected, resetQuery: resetQuery);

            Assert.That(api.QueryString, Is.EqualTo(expectedQuery));
        }

        [Test]
        public void find_by_id_list()
        {
            var created = Given_an_invoice();
            var invoices = Api.Invoices.Ids(new[] {created.Id}).Find().ToList();

            Assert.AreEqual(1, invoices.Count());
            Assert.AreEqual(created.Id, invoices.First().Id);
        }

        [Test]
        public void find_by_statuses_list()
        {
            var created = Given_an_invoice();
            var invoices = Api.Invoices.Statuses(new[] {created.Status}).Find().ToList();

            Assert.True(invoices.Any(it => it.Id == created.Id));
        }

        [Test]
        public void find_by_contact_id_list()
        {
            var created = Given_an_invoice();
            var invoices = Api.Invoices.ContactIds(new[] {created.Contact.Id}).Find().ToList();

            Assert.True(invoices.Any(it => it.Id == created.Id));
        }

        [Test]
        public void find_by_invoice_number_list()
        {
            var created = Given_an_invoice(invoiceNumber: Guid.NewGuid().ToString());
            var invoices = Api.Invoices.InvoiceNumbers(new[] {created.Number}).Find().ToList();

            Assert.True(invoices.Any(it => it.Id == created.Id));
        }

        [Test]
        public void find_by_mixture_of_query_param_lists()
        {
            var created = Given_an_invoice(invoiceNumber: Guid.NewGuid().ToString());
            var invoices = Api.Invoices
                .Ids(new [] {created.Id})
                .ContactIds(new [] { created.Contact.Id })
                .Statuses(new [] {created.Status})
                .InvoiceNumbers(new [] {created.Number})
                .Find().ToList();

            Assert.True(invoices.Any(it => it.Id == created.Id));
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
