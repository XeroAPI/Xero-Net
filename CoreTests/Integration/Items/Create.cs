using System;
using NUnit.Framework;
using Xero.Api.Core.Model;

namespace CoreTests.Integration.Items
{
    [TestFixture]
    public class Create : ApiWrapperTest
    {
        [Test]
        public void create_simple_item()
        {
            var code = "Woo-hoo " + Random.GetRandomString(10);

            var item = Api.Create(new Item
            {
                Code = code
            });

            Assert.IsTrue(Guid.Empty != item.Id);
            Assert.AreEqual(code, item.Code);
        }
    }
}
