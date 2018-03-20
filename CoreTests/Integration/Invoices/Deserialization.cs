using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xero.Api.Core.Model;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Serialization;
using Xero.Api.Core.Model.Types;

namespace CoreTests.Integration.Invoices
{
    [TestFixture]
    public class Deserialization
    {
        private IJsonObjectMapper _jsonMapper;
        private IXmlObjectMapper _xmlMapper;

        [TestFixtureSetUp]
        public void SetUp()
        {
            _jsonMapper = new DefaultMapper();
            _xmlMapper = new DefaultMapper();
        }

        [Test]
        public void nullable_type_json()
        {
            var invoice = createInvoice();

            var json = _jsonMapper.To(invoice);

            var deserialized = _jsonMapper.From<Invoice>(json);

            Assert.AreEqual(invoice.Id, deserialized.Id);
            Assert.AreEqual(invoice.Type, deserialized.Type);
        }

        [Test]
        public void nullable_type_xml()
        {
            var invoice = createInvoice();

            var xml = _xmlMapper.To(invoice);

            var deserialized = _xmlMapper.From<Invoice>(xml);

            Assert.AreEqual(invoice.Id, deserialized.Id);
            Assert.AreEqual(invoice.Type, deserialized.Type);
        }

        private static Invoice createInvoice()
        {
            return new Invoice()
            {
                Id = Guid.NewGuid(),
                Type = InvoiceType.AccountsReceivable
            };
        }
    }
}
