using NUnit.Framework;
using System;
using System.Collections.Generic;
using Xero.Api.Core.Model;

namespace CoreTests.Integration.ContactGroups
{
    [TestFixture]
    public class Update : ContactGroupsTest
    {
        [Test]
        public void Can_I_change_the_name_of_a_contactgroup()
        {
            var contactgroup = Given_a_contactgroup();

            var newName = "Marketing Group" + Guid.NewGuid();

            contactgroup.Name = newName;
            
            var result =  Api.Update(contactgroup);

            Assert.IsTrue(result.Name.StartsWith("Marketing Group"));
        }

        [Test]
        protected void Can_I_append_contacts_to_a_contactgroup()
        {
            var contactgroup = Given_a_contactgroup();

            List<Contact> assign_1_contacts = new List<Contact>();

            assign_1_contacts.Add(Given_a_contact());

            Api.Assign(contactgroup, assign_1_contacts);

            List<Contact> assign_4_more_contacts = new List<Contact>();
            assign_4_more_contacts.Add(Given_a_contact());
            assign_4_more_contacts.Add(Given_a_contact());
            assign_4_more_contacts.Add(Given_a_contact());
            assign_4_more_contacts.Add(Given_a_contact());

            Api.Assign(contactgroup, assign_4_more_contacts);

            
        }
    }
}
