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

namespace CoreTests.Integration.CreditNotes
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

            var creditNote = _jsonMapper.From<CreditNote>(data);

            Assert.AreEqual(Guid.Parse("9f61dcc7-4bea-4267-9ba6-c4842ee0dc89"), creditNote.Id);
            Assert.AreEqual(CreditNoteType.AccountsPayable, creditNote.Type);
        }

        private string getApiData()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = typeof(Deserialization).Namespace + ".CreditNote.json";

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
            var creditNote = createCreditNote();

            var json = _jsonMapper.To(creditNote);

            var deserialized = _jsonMapper.From<CreditNote>(json);

            Assert.AreEqual(creditNote.Id, deserialized.Id);
            Assert.AreEqual(creditNote.Type, deserialized.Type);
        }

        [Test]
        public void nullable_type_roundtrip_xml()
        {
            var creditNote = createCreditNote();

            var xml = _xmlMapper.To(creditNote);

            var deserialized = _xmlMapper.From<CreditNote>(xml);

            Assert.AreEqual(creditNote.Id, deserialized.Id);
            Assert.AreEqual(creditNote.Type, deserialized.Type);
        }

        private static CreditNote createCreditNote()
        {
            return new CreditNote()
            {
                Id = Guid.NewGuid(),
                Type = CreditNoteType.AccountsReceivable
            };
        }
    }
}
