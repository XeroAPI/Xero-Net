using NUnit.Framework;

namespace CoreTests.Integration.ContactGroups
{
    [TestFixture]
    public class Create : ContactGroupsTest
    {
        [Test]
        public void Can_I_create_a_contactgroup()
        {
           var name= Given_a_contactgroup().Name;
           
            Assert.IsTrue(name.StartsWith("Nice People"));

        }
    }
}
