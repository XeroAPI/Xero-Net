using NUnit.Framework;

namespace CoreTests.Integration.HistoryAndNotes
{
    public class Find : HistoryAndNotesTest
    {
        [Test]
        public void Can_fetch_history_and_notes()
        {
            Given_a_contact();

            When_I_retrieve_history_and_notes_for_the_contact();

            Then_there_are_some_history_records();
        }
    }
}
