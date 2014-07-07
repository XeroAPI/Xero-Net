using NUnit.Framework;
using Xero.Api.Core.Model.Types;

namespace CoreTests.Integration.CreditNotes
{
    [TestFixture]
    public class Create : CreditNotesTest
    {
        [Test]
        public void create_creditnote()
        {
            const CreditNoteType expected = CreditNoteType.AccountsReceivable;

            var type = Given_a_creditnote(expected).Type;

            Assert.AreEqual(expected, type);
        }
    }
}
   
