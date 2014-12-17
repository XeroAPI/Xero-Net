using NUnit.Framework;
using System.Collections.Generic;
using Xero.Api.Core.Model;

namespace CoreTests.Integration.ContactGroups
{
    [TestFixture]
    public class Assign : ContactGroupsTest
    {
        [Test]
        public void Can_I_assign_a_contact_to_a_contactgroup()
        {
            var contactgroup = Given_a_contactgroup();

            List<Contact> contacts = new List<Contact>();

            contacts.Add(Given_a_contact());

            Api.ContactGroups.AssignContacts(contactgroup, contacts);
        }
    }
}
