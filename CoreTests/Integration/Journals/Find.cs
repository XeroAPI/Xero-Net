using System.Linq;
using NUnit.Framework;

namespace CoreTests.Integration.Journals
{
    [TestFixture]
    public class Find : ApiWrapperTest
    {
        [Test]
        public void find_journals()
        {
            var journals = Api.Journals.Find();

            Assert.That(journals.Any());
        }

        [Test]
        public void find_journals_offset()
        {
            var journals = Api.Journals.Find().ToList();

            if (journals.Count() == 100)
            {
                var offset = journals.Max(p => p.Number);

                Assert.That(Api.Journals.Offset(offset)
                    .Find()
                    .Any());
            }
        }
    }
}
