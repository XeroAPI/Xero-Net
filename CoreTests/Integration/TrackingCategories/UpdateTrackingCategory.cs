using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Xero.Api.Core.Endpoints;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Status;

namespace CoreTests.Integration.TrackingCategories
{
    [TestFixture]
    public class UpdateTrackingCategory : TrackingCategoriesTest
    {
        [Test]
        public void Can_update_tracking_category_name()
        {
            var category = Given_a_TrackingCategory();

            category.Name = "The Penguin";

            var result = Api.Update(category);

            Assert.True(result.Name == "The Penguin");

            Given_Tracking_Category_is_deleted(category);
        }

        [Test]
        public void Can_update_tracking_category_with_options_name()
        {
            var category = Given_a_TrackingCategory_with_Options();

            category.Name = "The Joker";

            var result = Api.Update(category);

            Assert.True(result.Name == "The Joker");

            Given_Tracking_Category_is_deleted(category);
        }
    }
}
