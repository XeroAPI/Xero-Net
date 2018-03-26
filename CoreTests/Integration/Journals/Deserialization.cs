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

namespace CoreTests.Integration.Journals
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

            var journal = _jsonMapper.From<Journal>(data);

            Assert.AreEqual(Guid.Parse("56f1ed45-c27b-4621-a2b0-7c26e0ead86a"), journal.Id);
            Assert.AreEqual(SourceType.AccountsReceivableInvoice, journal.SourceType);
        }

        private string getApiData()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = typeof(Deserialization).Namespace + ".Journal.json";

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
            var journal = createJournal();

            var json = _jsonMapper.To(journal);

            var deserialized = _jsonMapper.From<Journal>(json);

            Assert.AreEqual(journal.Id, deserialized.Id);
            Assert.AreEqual(journal.SourceType, SourceType.AccountsPayablePrepayment);
        }

        [Test]
        public void nullable_type_roundtrip_xml()
        {
            var journal = createJournal();

            var xml = _xmlMapper.To(journal);

            var deserialized = _xmlMapper.From<Journal>(xml);

            Assert.AreEqual(journal.Id, deserialized.Id);
            Assert.AreEqual(journal.SourceType, SourceType.AccountsPayablePrepayment);
        }

        private static Journal createJournal()
        {
            return new Journal()
            {
                Id = Guid.NewGuid(),
                SourceType = SourceType.AccountsPayablePrepayment
            };
        }
    }
}
