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
            var category = Given_a_TrackingCategory();

            Assert.IsTrue(category.Name.StartsWith("TheJoker"));
            
            Assert.IsTrue(category.Status == TrackingCategoryStatus.Active);

            Given_Tracking_Category_is_deleted(category);
        }
    }
}
