using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Xero.Api.Core.Model;

namespace CoreTests.Integration.ContactGroups
{
    [TestFixture]
    public class Create : ContactGroupsTest
    {

        

        [Test]
        public void Can_I_create_a_contactgroup()
        {

           var name= Given_a_contactgroup().Name;
           Assert.IsTrue(name.StartsWith("Nice People"));

        }



         // move to update class
         [Test]
         public void Can_I_change_the_name_of_a_contactgroup()
         {

             var contactgroup = Given_a_contactgroup();
             contactgroup.Name = "Marketing Group" + Guid.NewGuid();
             var newname = Api.ContactGroups.Update(contactgroup).Name;
             Assert.IsTrue(newname.StartsWith("Marketing Group"));

         }

         // move to remove class
         [Test]
         protected void Can_I_remove_the_contactgroup()
         {
             var contactgroup = Given_a_contactgroup();
             contactgroup.Status = "DELETED";
             var group = Api.ContactGroups.Update(contactgroup);

             //get all groups and make sure the group is not there.

         }

        
         [Test]
         public void Can_I_empty_the_contactgroup_of_contacts()
         {
            

             var contactgroup = Given_a_contactgroup();

             List<Contact> contacts = new List<Contact>();
             contacts.Add(Given_a_contact());
             contacts.Add(Given_a_contact());
             contacts.Add(Given_a_contact());
             contacts.Add(Given_a_contact());
             contacts.Add(Given_a_contact());

             Api.ContactGroups.AssignContacts(contactgroup, contacts);

             // this is implemented in 2.68+ so will return 404 for now.
             Api.ContactGroups.EmptyGroup(contactgroup);

         }

        //[Test]
        //protected void Can_I_assign_a_contact_to_a_contactgroup()
        //{
        //    var contactgroup = Given_a_contactgroup();

        //    List<Contact> contacts = new List<Contact>();
        //    contacts.Add(Given_a_contact());

        //    Api.ContactGroups.AssignContacts(contactgroup, contacts);

        //}

        //[Test]
        //protected void Can_I_append_contacts_to_a_contactgroup()
        //{
        //    var contactgroup = Given_a_contactgroup();

        //    List<Contact> assign_1_contacts = new List<Contact>();
        //    assign_1_contacts.Add(Given_a_contact());
        //    Api.ContactGroups.AssignContacts(contactgroup, assign_1_contacts);

        //    List<Contact> assign_4_more_contacts = new List<Contact>();
        //    assign_4_more_contacts.Add(Given_a_contact());
        //    assign_4_more_contacts.Add(Given_a_contact());
        //    assign_4_more_contacts.Add(Given_a_contact());
        //    assign_4_more_contacts.Add(Given_a_contact());

        //    Api.ContactGroups.AssignContacts(contactgroup, assign_4_more_contacts);



        //}

        
    }
}
