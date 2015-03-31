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
    public class AddTrackingOption : TrackingCategoriesTest
    {
        [Test]
        public void Can_add_tracking_option()
        {
            var category = Given_a_TrackingCategory();

            var option = Given_a_tracking_option();

            Api.TrackingCategories[category.Id].Add(option);

            var result = Api.TrackingCategories[category.Id];

            Assert.True(result._trackingCat.Options.FirstOrDefault().Name == option.Name);

            Given_Tracking_Category_is_deleted(category);
        }

        [Test]
        public void Can_add_tracking_options()
        {
            var category = Given_a_TrackingCategory();

            var options = Given_a_tracking_options();

            Api.TrackingCategories[category.Id].Add(options);

            var result = Api.TrackingCategories[category.Id];

            Assert.True(result._trackingCat.Options.Any(i=>i.Name == options.FirstOrDefault().Name));
            Assert.True(result._trackingCat.Options.Any(i=>i.Name == options.Last().Name));

            Given_Tracking_Category_is_deleted(category);
        }
    }
}
