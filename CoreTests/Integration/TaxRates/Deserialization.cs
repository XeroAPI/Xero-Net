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

namespace CoreTests.Integration.TaxRates
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
        public void nullable_type_roundtrip_json()
        {
            var taxRate = createCreditNote();

            var json = _jsonMapper.To(taxRate);

            var deserialized = _jsonMapper.From<TaxRate>(json);

            Assert.IsFalse(object.ReferenceEquals(taxRate, deserialized));
            Assert.AreEqual(taxRate.Name, deserialized.Name);
            Assert.AreEqual(taxRate.EffectiveRate, deserialized.EffectiveRate);
        }

        [Test]
        public void nullable_type_roundtrip_xml()
        {
            var taxRate = createCreditNote();

            var xml = _xmlMapper.To(taxRate);

            var deserialized = _xmlMapper.From<TaxRate>(xml);

            Assert.IsFalse(object.ReferenceEquals(taxRate, deserialized));
            Assert.AreEqual(taxRate.Name, deserialized.Name);
            Assert.AreEqual(taxRate.EffectiveRate, deserialized.EffectiveRate);
        }

        private static TaxRate createCreditNote()
        {
            return new TaxRate()
            {
                Name = Guid.NewGuid().ToString(),
                EffectiveRate = 5,
            };
        }
    }
}
