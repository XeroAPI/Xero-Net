using System;
using NUnit.Framework;

namespace CoreTests.Integration.HistoryAndNotes
{
    public class CreateNotes : HistoryAndNotesTest
    {
        [Test]
        public void Can_create_notes()
        {
            var date = DateTime.UtcNow;
            const string details = "Details";

            Given_a_contact();

            Given_a_note_with_this_date_and_details(date, details);

            When_I_retrieve_history_and_notes_for_the_contact();

            Then_there_is_a_note_with_the_correct_details(date, details);
        }

        [Test]
        public void Validation_errors_are_as_expected()
        {
            Given_a_contact();

            Given_a_note_with_this_date_and_details(new DateTime(1000, 1, 1), "Details");

            When_I_retrieve_history_and_notes_for_the_contact();

            Then_there_is_this_validation_error("sad");
        }
    }
}
