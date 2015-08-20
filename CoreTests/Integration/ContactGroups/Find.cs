using System.Linq;
using NUnit.Framework;

namespace CoreTests.Integration.ContactGroups
{
    [TestFixture]
    public class Find : ContactGroupsTest
    {
        [Test]
        public void Can_Find_Contact_Group()
        {
            var contactGroup = Given_a_contactgroup();

            var foundContactGroup = Api.ContactGroups.Find(contactGroup.Id);

            Assert.IsTrue(foundContactGroup.Name.StartsWith("Nice People"));
        }

        [Test]
        public void Can_Find_Contacts_in_Contact_Group()
        {
            var contactGroup = Given_a_contactgroup();

            var contact = Given_a_contact();

            Api.ContactGroups[contactGroup.Id].Add(contact);

            var foundContactGroup = Api.ContactGroups.Find(contactGroup.Id);

            Assert.IsTrue(foundContactGroup.Name.StartsWith("Nice People"));
            Assert.IsTrue(foundContactGroup.Contacts.FirstOrDefault().Name.StartsWith("Peter"));
        }
    }
}
