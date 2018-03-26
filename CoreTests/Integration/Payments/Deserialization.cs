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
using System.Reflection;
using System.IO;

namespace CoreTests.Integration.Payments
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
        public void api_payload_json()
        {
            var data = getApiData();

            var payment = _jsonMapper.From<Payment>(data);

            Assert.AreEqual(Guid.Parse("90f3923a-f46a-4588-a004-be9147f8c505"), payment.Id);
            Assert.AreEqual(PaymentType.AccountsReceivableOverpayment, payment.Type);
        }

        private string getApiData()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = typeof(Deserialization).Namespace + ".Overpayment.json";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();
                return result;
            }
        }

        [Test]
        public void nullable_type_roundtrip_json()
        {
            var creditNote = createPayment();

            var json = _jsonMapper.To(creditNote);

            var deserialized = _jsonMapper.From<Payment>(json);

            Assert.AreEqual(creditNote.Id, deserialized.Id);
            Assert.AreEqual(creditNote.Type, deserialized.Type);
        }

        [Test]
        public void nullable_type_roundtrip_xml()
        {
            var creditNote = createPayment();

            var xml = _xmlMapper.To(creditNote);

            var deserialized = _xmlMapper.From<Payment>(xml);

            Assert.AreEqual(creditNote.Id, deserialized.Id);
            Assert.AreEqual(creditNote.Type, deserialized.Type);
        }

        private static Payment createPayment()
        {
            return new Payment()
            {
                Id = Guid.NewGuid(),
                Type = PaymentType.AccountsPayable
            };
        }
    }
}
