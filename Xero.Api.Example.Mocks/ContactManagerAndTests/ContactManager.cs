using System.Collections.Generic;
using System.Linq;
using Xero.Api.Core.Model;

namespace Xero.Api.Example.Mocks.ContactManagerAndTests
{
    public class ContactManager
    {
        // This is an example of an Address manager. It processes contacts returning contacts on differenet filters.

        private readonly IEnumerable<Contact> _contacts;

        public ContactManager(IEnumerable<Contact> contacts)
        {
            _contacts = contacts;
        }

        public IEnumerable<Contact> ContactsFromTatooine()
        {
            return ContactsFrom("Tatooine");
        }

        public IEnumerable<Contact> ContactsFromDagobah()
        {
            return ContactsFrom("Dagobah");
        }

        private IEnumerable<Contact> ContactsFrom(string country)
        {
            return _contacts.Where(contact => contact.Addresses.First().Country == country).ToList();            
        } 
    }
}
