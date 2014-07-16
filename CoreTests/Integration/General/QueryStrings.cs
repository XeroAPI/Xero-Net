using System;
using NUnit.Framework;

namespace CoreTests.Integration.General
{
    [TestFixture]
    public class QueryStrings : ApiWrapperTest
    {
        [Test]
        public void query_string_is_as_expected()
        {
            Assert.DoesNotThrow(() => Api.Invoices.Where("Status == \"ACTIVE\"").Find());            
        }

        [Test]
        public void complex_query_string_is_as_expected()
        {
            var startDate = DateTime.UtcNow.AddDays(-30).Date.ToString("yyyy-MM-dd");
            var endDate = DateTime.UtcNow.Date.ToString("yyyy-MM-dd");

            Assert.DoesNotThrow(() => Api.Invoices.Where("Status == \"ACTIVE\"")
                .And(string.Format("DueDate >= DateTime.Parse(\"{0}\")", startDate))
                .And(string.Format("DueDate <= DateTime.Parse(\"{0}\")", endDate))
                .OrderByDescending("DueDate").Find());
        }

        [Test]
        public void contact_query_string_is_as_expected()
        {
            Assert.DoesNotThrow(() => Api.Contacts.IncludeArchived(true).Find());
        }
    }
}
