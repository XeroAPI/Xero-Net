using System;
using System.Linq;
using NUnit.Framework;

namespace CoreTests.Integration.ManualJournals
{
    [TestFixture]
    public class Find : ManualJournalsTest
    {
        [TestFixtureSetUp]
        public void UpdateSet()
        {
            ManualJournalsSetUp();
        }

        [Test]
        public void find_by_id()
        {
            const string expected = "We know what we want to do";
            var manual = Given_a_manual_journal(expected, 50);

            var found = Api.ManualJournals.Find(manual.Id);

            Assert.AreEqual(DateTime.Now.Date, found.Date);
            Assert.AreEqual(expected, found.Narration);
        }

        [Test]
        public void find_by_value()
        {
            const string expected = "We know what we want to do";
            
            Given_a_manual_journal(expected, 50);

            var found = Api.ManualJournals
                .Where(string.Format("Narration == \"{0}\"", expected))
                .Find();

            Assert.True(found.All(p => p.Narration == expected));
        } 
    }
}