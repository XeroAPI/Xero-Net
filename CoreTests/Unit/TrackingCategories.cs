using NUnit.Framework;

namespace CoreTests.Unit
{
    [TestFixture]
    public class TrackingCategories : ApiWrapperTest
    {
        [SetUp]
        public void TestSetUp()
        {
            Api.TrackingCategories.ClearQueryString();
        }

        [Test]
        public void include_archived()
        {
            const string expected = "includeArchived=true";

            var query = Api.TrackingCategories.IncludeArchived(true)
                .QueryString;

            Assert.AreEqual(expected, query);
        }

        [Test]
        public void exclude_archived_explict()
        {
            var query = Api.TrackingCategories.IncludeArchived(false)
                .QueryString;

            Assert.AreEqual(string.Empty, query);
        }

        [Test]
        public void exclude_archived_implict()
        {
            var query = Api.TrackingCategories.QueryString;

            Assert.AreEqual(string.Empty, query);
        }
    }
}