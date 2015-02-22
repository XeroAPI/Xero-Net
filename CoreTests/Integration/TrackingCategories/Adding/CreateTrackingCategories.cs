using System;
using NUnit.Framework;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Status;

namespace CoreTests.Integration.TrackingCategories
{
    [TestFixture]
    public class CreateTrackingCategories : TrackingCategoriesTest
    {
        [Test]
        public void Can_create_a_Tracking_Category()
        {
            var category = Api.Create(new TrackingCategory
            {
                Id = new Guid(),
                Name = "TheJoker " + Guid.NewGuid(),
                Status = TrackingCategoryStatus.Active
            });

            Assert.IsTrue(category.Name.StartsWith("TheJoker"));
            Assert.IsTrue(category.Status == TrackingCategoryStatus.Active);

//            Archieve_a_TrackingCategoy(category);
        }

    }
}
