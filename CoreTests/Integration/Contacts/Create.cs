using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Xero.Api.Core.Model;

namespace CoreTests.Integration.Contacts
{
    [TestFixture]
    public class Create : ContactsTest
    {
        [Test]
        public void create_contact()
        {
            var name = Given_a_contact().Name;

            Assert.IsTrue(name.StartsWith("Peter"));
        }

        [Test]
        public void create_many_contact()
        {
            var contacts = Api.Create(new List<Contact>
            {
                new Contact
                {
                    Name = "John " + Random.GetRandomString(10)
                },
                new Contact
                {
                    Name = "Paul" + Random.GetRandomString(10)
                },
                new Contact
                {
                    Name = "George" + Random.GetRandomString(10)
                },
                new Contact
                {
                    Name = "Ringo" + Random.GetRandomString(10)
                }
            });

            Assert.AreEqual(4, contacts.Count());
        }

        [Test]
        public void create_complex_contact()
        {
            Api.Contacts.SummarizeErrors(true);

            var expectedAccountNumber = "AccountNumber" + Random.GetRandomString(10);


            var contact = Api.Create(new Contact
            {
                Name = "24 locks " + Random.GetRandomString(10),
                FirstName = "Ben",
                LastName = "Bowden",
                EmailAddress = "ben.bowden@24locks.com",
                AccountNumber = expectedAccountNumber,

                ContactPersons = new List<ContactPerson>
                {
                    new ContactPerson
                    {
                        FirstName = "John",
                        LastName = "Smith",
                        EmailAddress = "john.smith@24locks.com",
                        IncludeInEmails = true
                    }
                }
            });

            Assert.AreEqual("Ben", contact.FirstName);
            Assert.AreEqual("John", contact.ContactPersons[0].FirstName);
            Assert.AreEqual(expectedAccountNumber, contact.AccountNumber);
        }
    }
}
