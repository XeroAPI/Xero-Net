using NUnit.Framework;

namespace CoreTests.Unit
{
    [TestFixture]
    public class Contacts : ApiWrapperTest
    {
        [SetUp]
        public void Setup()
        {
            Api.Invoices.ClearQueryString();
            Api.ExpenseClaims.ClearQueryString();
        }

        [Test]
        public void contact_include_archived()
        {
            const string expected = "page=1&includeArchived=true";

            var query = Api.Contacts.IncludeArchived(true)
                .QueryString;

            Assert.AreEqual(expected, query);
        }

        [Test]
        public void contact_exclude_archived()
        {
            const string expected = "page=1";

            var query = Api.Contacts.IncludeArchived(false)
                .QueryString;

            Assert.AreEqual(expected, query);
        }
    }
}