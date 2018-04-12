using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Types;

namespace CoreTests.Integration.HistoryAndNotes
{
    public class HistoryAndNotesTest : ApiWrapperTest
    {
        private Contact _contact;
        private IEnumerable<HistoryRecord> _historyRecords;
        
        protected void Given_a_contact()
        {
            _contact = Api.Contacts.Create(new Contact { Name = Guid.NewGuid().ToString() });
        }

        protected void Given_a_note_with_these_details(string details)
        {
            Api.HistoryAndNotes.CreateNote(HistoryAndNotesEndpointCreateType.Contacts, _contact.Id,
                new HistoryRecord
                {
                    Details = details
                });
        }

        protected void When_I_retrieve_history_and_notes_for_the_contact()
        {
            _historyRecords = Api.HistoryAndNotes.Find(HistoryAndNotesEndpointRetrieveType.Contacts, _contact.Id);
        }

        protected void Then_there_are_some_history_records()
        {
            Assert.True(_historyRecords.Any(), "Expected some history records to be returned, but there were none");
        }

        protected void Then_there_is_a_note_with_the_correct_details(string details)
        {
            Assert.True(_historyRecords.Any(it => it.Details == details), "Expected a note with the expected details to be returned but it was not");
        }
    }
}
