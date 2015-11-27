using NUnit.Framework;

namespace CoreTests.Unit
{
    [TestFixture]
    public class Contacts : ApiWrapperTest
    {
        [Test]
        public void include_archived()
        {
            const string expected = "page=1&includeArchived=true";

            var query = Api.Contacts.IncludeArchived(true)
                .QueryString;

            Assert.AreEqual(expected, query);
        }

        [Test]
        public void exclude_archived_explict()
        {
            const string expected = "page=1";

            var query = Api.Contacts.IncludeArchived(false)
                .QueryString;

            Assert.AreEqual(expected, query);
        }

        [Test]
        public void exclude_archived_implict()
        {
            const string expected = "page=1";

            var query = Api.Contacts.QueryString;

            Assert.AreEqual(expected, query);
        }
    }
}