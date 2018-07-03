using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Types;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Serialization;

namespace CoreTests.Integration.OrganisationDetails
{
    [TestFixture]
    public class Deserialization
    {
        private IJsonObjectMapper _jsonMapper;
        private IXmlObjectMapper _xmlMapper;

        public int SalesTaxBasis { get; private set; }

        [TestFixtureSetUp]
        public void SetUp()
        {
            _jsonMapper = new DefaultMapper();
            _xmlMapper = new DefaultMapper();
        }

        [Test]
        public void api_payload_json()
        {
            var data = getApiJsonData();

            var organisation = _jsonMapper.From<Organisation>(data);

            Assert.AreEqual(Guid.Parse("b1a33437-1024-4f13-85ce-eac7c2414456"), organisation.Id);
            Assert.AreEqual(organisation.SalesTaxBasis, SalesTaxBasisType.FlatRateAccrual);
        }

        private string getApiJsonData()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = typeof(Deserialization).Namespace + ".Organisation.json";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();
                return result;
            }
        }
    }
}
