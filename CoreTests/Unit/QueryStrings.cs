using System;
using NUnit.Framework;

namespace CoreTests.Unit
{
    [TestFixture]
    public class QueryStrings : ApiWrapperTest
    {
        [SetUp]
        public void Setup()
        {
            Api.Invoices.ClearQueryString();
        }

        [Test]
        public void query_string_is_as_expected()
        {
            var date = DateTime.UtcNow.Date.ToString("d");

            var expected = string.Format("where=Status == \"ACTIVE\" AND DueDate <= DateTime.Parse(\"{0}\")&unitdp=4&page=1", date);

            var query = Api.Invoices.Where("Status == \"ACTIVE\"")
                .And(string.Format("DueDate <= DateTime.Parse(\"{0}\")", date))
                .QueryString;
            
            Assert.AreEqual(expected, query);
        }

        [Test]
        public void complex_query_string_is_as_expected()
        {
            var startDate = DateTime.UtcNow.AddDays(-30).Date.ToString("d");
            var endDate = DateTime.UtcNow.Date.ToString("d");

            var expected = string.Format("where={0}&order=DueDate DESC&unitdp=4&page=1",
                string.Format("Status == \"ACTIVE\" AND DueDate >= DateTime.Parse(\"{0}\") AND DueDate <= DateTime.Parse(\"{1}\")", startDate, endDate));

            var query = Api.Invoices.Where("Status == \"ACTIVE\"")
                .And(string.Format("DueDate >= DateTime.Parse(\"{0}\")", startDate))
                .And(string.Format("DueDate <= DateTime.Parse(\"{0}\")", endDate))
                .OrderByDescending("DueDate")
                .QueryString;

            Assert.AreEqual(expected, query);
        }        
    }
}
