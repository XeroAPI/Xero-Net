using System.Linq;
using NUnit.Framework;
using Xero.Api.Core.Model.Types;

namespace CoreTests.Integration.CreditNotes
{
    [TestFixture]
    public class Find : CreditNotesTest
    {
        [Test]
        public void find_all_creditnotes()
        {
            Given_a_creditnote();

            Assert.True(Api.CreditNotes.Find().Any());
        }

        [Test]
        public void find_by_id()
        {
            var expected = Given_a_creditnote().Id;
            var id = Api.CreditNotes.Find(expected).Id;

            Assert.AreEqual(expected, id);
        }

        [Test]
        public void find_by_value()
        {
            Given_a_creditnote();

            var creditnote = Api.CreditNotes
                .Where("Type == \"ACCPAYCREDIT\"")
                .Find()
                .First()
                .Type;

            Assert.AreEqual(CreditNoteType.AccountsPayable, creditnote);
        }

        [Test]
        public void find_orderby_value()
        {
            Given_a_creditnote();

            var creditNote = Api.CreditNotes
                .OrderBy("Type")
                .Find()
                .First()
                .Type;

            Assert.AreEqual(CreditNoteType.AccountsPayable, creditNote);
        }
    }
}
