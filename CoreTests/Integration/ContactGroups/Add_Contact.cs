using NUnit.Framework;
using System;
using Xero.Api.Infrastructure.Exceptions;

namespace CoreTests.Integration.ContactGroups
{
    [TestFixture]
    public class Add_Contact : ContactGroupsTest
    {
        [Test]
        public void Can_I_add_a_contact_to_a_contactgroup()
        {
            var contactgroup = Given_a_contactgroup();

            Api.ContactGroups[contactgroup.Id].Add(Given_a_contact());
        }

        [Test]
        public void But_not_with_a_group_like_this()
        {
            Assert.Throws<NotFoundException>(() =>
            {
                Api.ContactGroups[Guid.Empty].Add(Given_a_contact());

            });
        }

    }
}
