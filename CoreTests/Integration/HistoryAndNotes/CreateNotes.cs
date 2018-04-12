using NUnit.Framework;

namespace CoreTests.Integration.HistoryAndNotes
{
    public class CreateNotes : HistoryAndNotesTest
    {
        [Test]
        public void Can_create_notes()
        {
            const string details = "Details";

            Given_a_contact();

            Given_a_note_with_these_details(details);

            When_I_retrieve_history_and_notes_for_the_contact();

            Then_there_is_a_note_with_the_correct_details(details);
        }
    }
}
