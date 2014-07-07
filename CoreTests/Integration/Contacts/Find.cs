using System;
using System.Linq;
using NUnit.Framework;
using Xero.Api.Core.Model.Status;

namespace CoreTests.Integration.Contacts
{
    [TestFixture]
    public class Find : ContactsTest
    {
        [Test]
        public void find_by_page()
        {
            Given_a_contact();

            Assert.True(Api.Contacts.Page(1).Find().Any());
        }

        [Test]
        public void find_by_id()
        {
            var expected = Given_a_contact().Id;
            
            var id = Api.Contacts
                .Find(expected)
                .Id;

            Assert.AreEqual(expected, id);
        }

        [Test]
        public void find_by_value()
        {
            var expected = Given_a_contact().Name;

            var name = Api.Contacts
                .Where(string.Format("Name == \"{0}\"", expected))
                .Find()
                .Select(p => p.Name);                

            Assert.True(name.All(p => p == expected));
        }

        [Test]
        public void find_by_contains_value()
        {
            var expected = Given_a_contact().Name;

            var contacts = Api.Contacts
                .Where(string.Format("Name.Contains(\"{0}\")", expected))
                .Find()
                .Select(p => p.Name);

            Assert.True(contacts.All(p => p.Contains(expected)));            
        }

        [Test]
        public void find_by_status()
        {
            Given_a_contact();

            var status = Api.Contacts
                .Where("ContactStatus == \"ACTIVE\"")
                .Find()
                .Select(p => p.ContactStatus);                

            Assert.True(status.All(p => p == ContactStatus.Active));
        }

        [Test]
        public void find_by_updated_date()
        {
            var expected = Given_a_contact().Id;
            var date = DateTime.Today.AddDays(-5);

            var contacts = Api.Contacts
                .ModifiedSince(date)
                .Find()
                .Select(p => p.Id)
                .ToList();

            Assert.Greater(contacts.Count(), 0);
            Assert.Contains(expected, contacts);
        }
        
        [Test]
        public void find_by_dateRange()
        {
            var expected = Given_a_contact().Id;
            var fromDate = DateTime.Today.AddDays(-3);
            var toDate = DateTime.Today.AddDays(1);

            var contacts = Api.Contacts
                .Where(string.Format("UpdatedDateUTC >= DateTime.Parse(\"{0}\")", fromDate.ToString("yyyy-MM-dd")))
                .And(string.Format("UpdatedDateUTC <= DateTime.Parse(\"{0}\")", toDate.ToString("yyyy-MM-dd")))
                .Find()
                .Select(p => p.Id)
                .ToList();

            Assert.Greater(contacts.Count(), 0);
            Assert.Contains(expected, contacts);
        }
    }
}
